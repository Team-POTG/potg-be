using System.Collections.Immutable;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoreLinq;
using potg.Data;
using potg.Data.Dto;
using potg.Data.Dto.Spectator;
using potg.Data.Types;
using potg.Database.Entities;
using potg.Database.Entities.Match;
using potg.Database.Entities.Match.Timeline;
using potg.Database.Entities.Match.Timeline.Events;
using potg.Database.Repositories;
using potg.RiotGames.Dto.League;
using potg.RiotGames.Dto.Match;
using potg.RiotGames.Dto.Spectator;
using potg.RiotGames.Services;
using potg.RiotGames.Types;
using potg.Services;
using potg.Tools;
using Swashbuckle.AspNetCore.Annotations;
using ParticipantEntity = potg.Database.Entities.Match.ParticipantEntity;

namespace potg.Controllers;

[Route("api/potg-lol/[Controller]/{region}")]
[ApiExplorerSettings(GroupName = "POTG Summoner v1")]
[ApiController]
public class SummonerController : ControllerBase
{
    private readonly SummonerService _summonerService;
    private readonly LeagueService _leagueService;
    private readonly MatchService _matchService;
    private readonly SpectatorService _spectatorService;
    private readonly SummonerRepository _summonerRepository;
    private readonly RawMatchRepository _rawMatchRepository;
    private readonly MatchRepository _matchRepository;
    private readonly IMapper _mapper;
    private readonly JobQueueService _jobQueue;

    public SummonerController(SummonerService summonerService, MatchService matchService, LeagueService leagueService, SummonerRepository summonerRepository, RawMatchRepository rawMatchRepository, MatchRepository matchRepository, IMapper mapper, JobQueueService jobQueue, SpectatorService spectatorService)
    {
        _summonerService = summonerService;
        _summonerRepository = summonerRepository;
        _leagueService = leagueService;
        _mapper = mapper;
        _jobQueue = jobQueue;
        _spectatorService = spectatorService;
        _rawMatchRepository = rawMatchRepository;
        _matchRepository = matchRepository;
        _matchService = matchService;
    }

    #region Api

    [HttpGet]
    [SwaggerOperation(OperationId = "GetSummoner")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(SummonerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status405MethodNotAllowed)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status429TooManyRequests)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status502BadGateway)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status504GatewayTimeout)]
    [Route("by-name/{summonerName}")]
    public async Task<IActionResult> GetSummoner(string summonerName, string region = "kr", [FromQuery] bool? reFetch = null)
    {
        var query = await _summonerRepository.GetByName(summonerName, region);
        var found = query != null && (DateTime.Now - query.LastUpdate).TotalDays < 7;

        try
        {
            if (!found)
            {
                using var summonerResponse = await _summonerService.GetSummoner(summonerName, region);
                if (summonerResponse.IsSuccessStatusCode && summonerResponse.Content != null)
                {
                    var summoner = summonerResponse.Content;
                    using var leagueResponse = await _leagueService.GetLeagueEntries(summoner.Id, region);
                    if (leagueResponse.IsSuccessStatusCode && leagueResponse.Content != null)
                    {
                        query = await SaveSummoner(region, summoner, leagueResponse.Content);
                    }
                    else
                    {
                        return StatusCode((int) leagueResponse.StatusCode, new FailResponse("GetLeagueEntries가 올바르지 않은 응답을 함.", (int) leagueResponse.StatusCode));
                    }
                }
                else
                {
                    return StatusCode((int) summonerResponse.StatusCode, new FailResponse("GetSummoner가 올바르지 않은 응답을 함.", (int) summonerResponse.StatusCode));
                }
            }

            var result = _mapper.Map<SummonerEntity, SummonerDto>(query);
            using var gameResponse = await _spectatorService.GetCurrentGame(query.EncryptedSummonerId, region);
            if (gameResponse.IsSuccessStatusCode && gameResponse.Content != null)
            {
                var game = _mapper.Map<CurrentGameInfo, CurrentGameDto>(gameResponse.Content) with {Teams = new List<CurrentGameTeamDto>(2)};
                var participants = gameResponse.Content.Participants
                                               .Select(x => _mapper.Map<CurrentGameParticipant, CurrentGameParticipantDto>(x)).ToList();

                foreach (var participant in participants)
                {
                    if (!participant.Bot && participant.SummonerName != summonerName)
                    {
                        var searchQuery = await _summonerRepository.GetByName(participant.SummonerName, region);
                        if (searchQuery != null && (DateTime.Now - searchQuery.LastUpdate).TotalDays < 7)
                        {
                            participant.Level = searchQuery.Level;
                            participant.Ranks.AddRange(searchQuery.Ranks);
                        }
                        else
                        {
                            using var summonerResponse = await _summonerService.GetSummoner(participant.SummonerName, region);
                            if (summonerResponse.IsSuccessStatusCode && summonerResponse.Content != null)
                            {
                                var summoner = summonerResponse.Content;
                                using var leagueResponse = await _leagueService.GetLeagueEntries(participant.SummonerId, region);
                                if (leagueResponse.IsSuccessStatusCode && leagueResponse.Content != null)
                                {
                                    var summonerEntity = await SaveSummoner(region, summoner, leagueResponse.Content);
                                    participant.Level = summonerEntity.Level;
                                    participant.Ranks.AddRange(summonerEntity.Ranks);
                                }
                                else
                                {
                                    return StatusCode((int)leagueResponse.StatusCode, new FailResponse("GetLeagueEntries가 올바르지 않은 응답을 함.", (int)leagueResponse.StatusCode));
                                }
                            }
                            else
                            {
                                return StatusCode((int)summonerResponse.StatusCode, new FailResponse("GetSummoner가 올바르지 않은 응답을 함.", (int)summonerResponse.StatusCode));
                            }
                        }
                    }
                }

                var playerDictionary = participants.GroupBy(x => x.TeamId,
                                                       x => x)
                                                   .ToDictionary(x => x.Key, x => x.ToList());

                foreach (var (k, v) in playerDictionary)
                {
                    game.Teams.Add(new CurrentGameTeamDto
                    {
                        TeamId = k,
                        Participants = v
                    });
                }

                result = result with {CurrentGame = game};
                return StatusCode(200, result);
            }

            return StatusCode(200, query);
        }
        catch (Exception ex)
        {
            //TODO: 로그
            return StatusCode(500, new FailResponse("알 수 없는 오류", 500));
        }
    }

    [HttpGet]
    [SwaggerOperation(OperationId = "GetMatches")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(MatchEntity[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status405MethodNotAllowed)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status429TooManyRequests)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status502BadGateway)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status504GatewayTimeout)]
    [Route("{puuid}/matches")]
    public async Task<IActionResult> GetMatches(string puuid, string region = "asia") //TODO: 호출옵션 추가하기
    {
        try
        {
            using var matchIdsResponse = await _matchService.GetMatches(puuid, region, null, null, null, null, 0, 10);
            if (matchIdsResponse.IsSuccessStatusCode && matchIdsResponse.Content != null)
            {
                var matchIds = matchIdsResponse.Content.ToArray();
                var notPresentIds = (await _matchRepository.GetNotPresentCount(matchIds)).ToArray();
                var notPresentRawIds = (await _rawMatchRepository.GetNotPresentCount(notPresentIds)).ToImmutableArray();
                var matches = await _matchRepository.GetMatches(matchIds.Except(notPresentIds).ToArray()) ?? new();
                var rawMatches = await _rawMatchRepository.GetMatches(notPresentIds.Except(notPresentRawIds).ToArray()) ?? new();
                var idWithMatches = notPresentRawIds
                                    .ToDictionary(x => x, async x => await _matchService.GetMatch(x, region))
                                    .ToDictionary(x => x.Key, x => x.Value.Result)
                                    .AsParallel()
                                    .ToDictionary(x => x.Key, x => x.Value);
                var idWithTimelines = notPresentRawIds
                                      .ToDictionary(x => x, async x => await _matchService.GetMatchTimeline(x, region))
                                      .ToDictionary(x => x.Key, x => x.Value.Result)
                                      .AsParallel()
                                      .ToDictionary(x => x.Key, x => x.Value);

                foreach (var id in notPresentRawIds)
                {
                    var matchResponse = idWithMatches[id];
                    var timelineResponse = idWithTimelines[id];

                    try
                    {
                        if (matchResponse.IsSuccessStatusCode && matchResponse.Content != null && timelineResponse.IsSuccessStatusCode && timelineResponse.Content != null)
                        {
                            var match = matchResponse.Content;
                            var rawTimeline = timelineResponse.Content.Info;
                            var rawMatchEntity = _mapper.Map<MatchDto, RawMatchEntity>(match);
                            var timeline = new TimelineEntity
                            {
                                FrameInterval = rawTimeline.FrameInterval,
                                Frames = _mapper.Map<List<FrameEntity>>(rawTimeline.Frames),
                                GameId = rawTimeline.GameId,
                                Participants = rawTimeline.Participants.ToImmutableDictionary(x => x.ParticipantId.ToString(), x => x.Puuid)
                            };

                            for (var i = 0; i < rawTimeline.Frames.Length; i++)
                            {
                                foreach (var o in rawTimeline.Frames[i].Events)
                                {
                                    switch (o.Type)
                                    {
                                        case EventType.BuildingKill:
                                            timeline.Frames[i].Events.Add(o.TowerType != null ? _mapper.Map<TowerKillEvent>(o) : _mapper.Map<BuildingKillEvent>(o));
                                            break;
                                        case EventType.ChampionKill:
                                            timeline.Frames[i].Events.Add(_mapper.Map<ChampionKillEvent>(o));
                                            break;
                                        case EventType.ChampionSpecialKill:
                                            timeline.Frames[i].Events.Add(o.MultiKillLength.HasValue ? _mapper.Map<MultiKillEvent>(o) : _mapper.Map<ChampionSpecialKillEvent>(o));
                                            break;
                                        case EventType.EliteMonsterKill:
                                            timeline.Frames[i].Events.Add(o.MonsterSubType != null ? _mapper.Map<DragonKillEvent>(o) : _mapper.Map<EliteMonsterKillEvent>(o));
                                            break;
                                        case EventType.GameEnd:
                                            timeline.Frames[i].Events.Add(_mapper.Map<GameEndEvent>(o));
                                            break;
                                        case EventType.ItemDestroyed:
                                            timeline.Frames[i].Events.Add(_mapper.Map<ItemDestroyEvent>(o));
                                            break;
                                        case EventType.ItemPurchased:
                                            timeline.Frames[i].Events.Add(_mapper.Map<ItemPurchaseEvent>(o));
                                            break;
                                        case EventType.ItemSold:
                                            timeline.Frames[i].Events.Add(_mapper.Map<ItemSellEvent>(o));
                                            break;
                                        case EventType.ItemUndo:
                                            timeline.Frames[i].Events.Add(_mapper.Map<ItemUndoEvent>(o));
                                            break;
                                        case EventType.LevelUp:
                                            timeline.Frames[i].Events.Add(_mapper.Map<LevelUpEvent>(o));
                                            break;
                                        case EventType.ObjectiveBountyPreStart:
                                            timeline.Frames[i].Events.Add(_mapper.Map<ObjectiveBountyPreStartEvent>(o));
                                            break;
                                        case EventType.ObjectiveBountyFinish:
                                            timeline.Frames[i].Events.Add(_mapper.Map<ObjectiveBountyFinishEvent>(o));
                                            break;
                                        case EventType.PauseEnd:
                                            timeline.Frames[i].Events.Add(_mapper.Map<PauseEndEvent>(o));
                                            break;
                                        case EventType.SkillLevelUp:
                                            timeline.Frames[i].Events.Add(_mapper.Map<SkillLevelUpEvent>(o));
                                            break;
                                        case EventType.TurretPlateDestroyed:
                                            timeline.Frames[i].Events.Add(_mapper.Map<TurretPlateDestroyEvent>(o));
                                            break;
                                        case EventType.WardKill:
                                            timeline.Frames[i].Events.Add(_mapper.Map<WardKillEvent>(o));
                                            break;
                                        case EventType.WardPlaced:
                                            timeline.Frames[i].Events.Add(_mapper.Map<WardPlaceEvent>(o));
                                            break;
                                        case EventType.ChampionTransform:
                                            timeline.Frames[i].Events.Add(_mapper.Map<ChampionTransformEvent>(o));
                                            break;
                                        case EventType.DragonSoulGiven:
                                            timeline.Frames[i].Events.Add(_mapper.Map<DragonSoulEvent>(o));
                                            break;
                                    }
                                }
                            }

                            rawMatchEntity.Timeline = timeline;
                            rawMatches.Add(rawMatchEntity);
                        }
                        else
                        {
                            //TODO: 로그
                            continue;
                        }
                    }
                    finally
                    {
                        matchResponse.Dispose();
                        timelineResponse.Dispose();
                    }
                }

                if (rawMatches.Count > 0)
                {
                    // await rawMatchRepository.Save(rawMatches);

                    foreach (var matchEntity in rawMatches)
                    {
                        await _rawMatchRepository.Save(matchEntity);
                    }
                }

                var potgMatches = rawMatches.Select(rawMatchEntity =>
                {
                    var match = _mapper.Map<RawMatchEntity, MatchEntity>(rawMatchEntity);
                    var events = rawMatchEntity.Timeline.Frames.SelectMany(x => x.Events).ToList();
                    var participants = rawMatchEntity.Info.Participants.Select(x => _mapper.Map<ParticipantsDto, ParticipantEntity>(x)).ToList();

                    #region Badges

                    var participantEntities = participants.ToList();
                    var bestDamage = participantEntities.Max(x => x.TotalDamageDealtToChampions);
                    var bestDamageTaken = participantEntities.Max(x => x.TotalDamageTaken);
                    var bestGoldEarned = participantEntities.Max(x => x.GoldEarned);

                    var damageBest = participantEntities.Where(x => x.TotalDamageDealtToChampions == bestDamage).ToList();
                    var tankBest = participantEntities.Where(x => x.TotalDamageTaken == bestDamageTaken).ToList();
                    var goldBest = participantEntities.Where(x => x.GoldEarned == bestGoldEarned).ToList();

                    damageBest.ForEach(x => x.Badges.Add(new BadgeEntity(BadgeRarity.Normal, "무호흡 딜러", "딜량 1위")));
                    tankBest.ForEach(x => x.Badges.Add(new BadgeEntity(BadgeRarity.Normal, "방탄유리", "받은 피해량 1위")));
                    goldBest.ForEach(x => x.Badges.Add(new BadgeEntity(BadgeRarity.Normal, "부자", "골드 획등량 1위")));

                    foreach (var participant in participantEntities)
                    {
                        if (events.Count(x => x is DragonKillEvent dragon && dragon.KillerId == participant.ParticipantId) >= 3)
                        {
                            participant.Badges.Add(new BadgeEntity(BadgeRarity.Rare, "드래곤 슬레이어", "드래곤을 3회 이상 처치"));
                        }


                        // 마무리 정렬
                        if (participant.Badges.Count > 1)
                        {
                            participant.Badges = participant.Badges.OrderByDescending(x => x.Rarity).ToList();
                        }
                    }

                    #endregion

                    foreach (var teamEntity in match.Teams)
                    {
                        teamEntity.Participants = new List<ParticipantEntity>(participantEntities.Where(x => x.TeamId == teamEntity.TeamId));
                    }

                    return match;
                }).ToImmutableList();


                if (potgMatches.Count > 0)
                {
                    //await matchRepository.Save(potgMatches);
                    foreach (var matchEntity in potgMatches)
                    {
                        await _matchRepository.Save(matchEntity);
                    }

                    matches.AddRange(potgMatches);
                }

                return Ok(matches);
            }
            else
            {
                return StatusCode((int) matchIdsResponse.StatusCode, new FailResponse("GetMatches가 올바르지 않은 응답을 함.", (int) matchIdsResponse.StatusCode));
            }
        }
        catch (Exception ex)
        {
            //TODO: 로그
            return StatusCode(500, new FailResponse("알 수 없는 오류", 500));
        }
    }

    #endregion

    private async Task<SummonerEntity> SaveSummoner(string region, RiotGames.Dto.Summoner.SummonerDto summoner, IEnumerable<LeagueEntryDto> league)
    {
        var now = DateTime.Now;
        var ranks = league.Select(x => _mapper.Map<LeagueEntryDto, LeagueRankEntity>(x)).ToList();
        var query = new SummonerEntity
        {
            Region = Utils.GetRegionFromSubRegion(region),
            SubRegion = region,
            EncryptedSummonerId = summoner.Id,
            AccountId = summoner.AccountId,
            Puuid = summoner.Puuid,
            Level = summoner.SummonerLevel,
            Name = summoner.Name,
            SearchName = summoner.Name.ToLower().Replace(" ", ""),
            ProfileIconId = summoner.ProfileIconId,
            LastUpdate = now,
            LastUpdateEpoch = Utils.GetEpochTime(now),
            Ranks = new List<LeagueRankEntity>()
        };
        var solo = ranks.FirstOrDefault(x => x.QueueType == "RANKED_SOLO_5x5");
        var flex = ranks.FirstOrDefault(x => x.QueueType == "RANKED_FLEX_SR");
        if (solo != null)
        {
            query.Ranks.Add(solo);
        }

        if (flex != null)
        {
            query.Ranks.Add(flex);
        }

        await _summonerRepository.Save(query);
        return query;
    }
}