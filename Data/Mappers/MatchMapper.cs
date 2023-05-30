using AutoMapper;
using potg.Database.Entities.Match;
using potg.Database.Entities.Match.Timeline;
using potg.Database.Entities.Match.Timeline.Events;
using potg.RiotGames;
using potg.RiotGames.Dto.Match;
using ParticipantEntity = potg.Database.Entities.Match.ParticipantEntity;

namespace potg.Data.Mappers;

public class MatchMapper : Profile
{
    public MatchMapper()
    {
        CreateMap<MatchDto, RawMatchEntity>();
        CreateMap<BanDto, BanEntity>()
            .ForMember(d => d.ChampionName,
                o => o.MapFrom(s => DataDragon.Instance.GetChampionIdByKey(s.ChampionId)));
        CreateMap<ObjectiveDto, ObjectiveEntity>();
        CreateMap<ObjectivesDto, ObjectivesEntity>();
        CreateMap<TeamDto, TeamEntity>();
        CreateMap<PerksDto, PerksEntity>();
        CreateMap<PerkStatsDto, PerkStatsEntity>();
        CreateMap<PerkStyleDto, PerkStyleEntity>();
        CreateMap<PerkStyleSelectionDto, PerkStyleSelectionEntity>();

        CreateMap<ParticipantsDto, ParticipantEntity>()
            .ForMember(d => d.Summoner1Id,
                o => o.MapFrom(s => DataDragon.Instance.GetSpellByKey(s.Summoner1Id.ToString()).Id))
            .ForMember(d => d.Summoner2Id,
                o => o.MapFrom(s => DataDragon.Instance.GetSpellByKey(s.Summoner2Id.ToString()).Id))
            .ForMember(d => d.ChampionName,
                o => o.MapFrom(s => DataDragon.Instance.GetChampionIdByKey(s.ChampionId)));


        CreateMap<RawMatchEntity, MatchEntity>()
            .ForMember(d => d.MatchId,
                o => o.MapFrom(s => s.Metadata.MatchId))
            .ForMember(d => d.Puuids,
                o => o.MapFrom(s => s.Metadata.Participants))
            .ForMember(d => d.GameDuration,
                o => o.MapFrom(s => s.Info.GameDuration))
            .ForMember(d => d.GameEndTimestamp,
                o => o.MapFrom(s => s.Info.GameEndTimestamp))
            .ForMember(d => d.GameId,
                o => o.MapFrom(s => s.Info.GameId))
            .ForMember(d => d.GameMode,
                o => o.MapFrom(s => s.Info.GameMode))
            .ForMember(d => d.GameType,
                o => o.MapFrom(s => s.Info.GameType))
            .ForMember(d => d.GameVersion,
                o => o.MapFrom(s => s.Info.GameVersion))
            .ForMember(d => d.MapId,
                o => o.MapFrom(s => s.Info.MapId))
            .ForMember(d => d.PlatformId,
                o => o.MapFrom(s => s.Info.PlatformId))
            .ForMember(d => d.QueueId,
                o => o.MapFrom(s => s.Info.QueueId))
            .ForMember(d => d.Teams,
                o => o.MapFrom(s => s.Info.Teams));

        CreateMap<TimelineInfoDto, TimelineEntity>();
        CreateMap<ParticipantFrameDto, ParticipantFrameEntity>();
        CreateMap<FrameDto, FrameEntity>()
            .ForMember(d => d.Events, o => o.MapFrom(s => new List<EventEntity>()));

        CreateMap<EventDto, BuildingKillEvent>();
        CreateMap<EventDto, TowerKillEvent>();
        CreateMap<EventDto, ChampionKillEvent>();
        CreateMap<EventDto, ChampionSpecialKillEvent>();
        CreateMap<EventDto, MultiKillEvent>();
        CreateMap<EventDto, EliteMonsterKillEvent>();
        CreateMap<EventDto, DragonKillEvent>();
        CreateMap<EventDto, GameEndEvent>();
        CreateMap<EventDto, ItemDestroyEvent>();
        CreateMap<EventDto, ItemPurchaseEvent>();
        CreateMap<EventDto, ItemSellEvent>();
        CreateMap<EventDto, ItemUndoEvent>();
        CreateMap<EventDto, LevelUpEvent>();
        CreateMap<EventDto, ObjectiveBountyPreStartEvent>();
        CreateMap<EventDto, ObjectiveBountyFinishEvent>();
        CreateMap<EventDto, PauseEndEvent>();
        CreateMap<EventDto, SkillLevelUpEvent>();
        CreateMap<EventDto, TurretPlateDestroyEvent>();
        CreateMap<EventDto, WardKillEvent>();
        CreateMap<EventDto, WardPlaceEvent>();
        CreateMap<EventDto, ChampionTransformEvent>();
        CreateMap<EventDto, DragonSoulEvent>();
    }
}