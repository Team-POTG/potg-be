using potg.RiotGames.Dto.Match;
using Refit;

namespace potg.RiotGames.Clients;

public interface IMatchClient
{
    [Get("/lol/match/v5/matches/by-puuid/{puuid}/ids")]
    Task<ApiResponse<IEnumerable<string>>> GetMatches([Header("X-Riot-Token")] string key,
                                                      string puuid,
                                                      [AliasAs("startTime")] long? startTime,
                                                      [AliasAs("endTime")] long? endTime,
                                                      [AliasAs("queue")] int? queue,
                                                      [AliasAs("type")] string? type,
                                                      [AliasAs("start")] int start,
                                                      [AliasAs("count")] int count);

    [Get("/lol/match/v5/matches/{matchId}")]
    Task<ApiResponse<MatchDto>> GetMatch([Header("X-Riot-Token")] string key,
                                         [AliasAs("matchId")] string matchId);

    [Get("/lol/match/v5/matches/{matchId}/timeline")]
    Task<ApiResponse<MatchTimelineDto>> GetMatchTimeline([Header("X-Riot-Token")] string key,
                                                 [AliasAs("matchId")] string matchId);
}