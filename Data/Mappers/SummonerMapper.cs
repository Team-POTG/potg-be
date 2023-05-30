using AutoMapper;
using potg.Data.Dto;
using potg.Data.Dto.Spectator;
using potg.Database.Entities;
using potg.RiotGames;
using potg.RiotGames.Dto.League;
using potg.RiotGames.Dto.Spectator;

namespace potg.Data.Mappers;

public class SummonerMapper : Profile
{
    public SummonerMapper()
    {
        CreateMap<LeagueEntryDto, LeagueRankEntity>()
            .ForMember(d => d.Tier,
                o => o.MapFrom(s => ConvertTier(s.Tier)))
            .ForMember(d => d.Rank,
                o => o.MapFrom(s => ConvertRank(s.Rank)));
        CreateMap<MiniSeriesDto, MiniSeriesEntity>();

        CreateMap<SummonerEntity, SummonerDto>();
        CreateMap<CurrentGameInfo, CurrentGameDto>();
        CreateMap<CurrentGameParticipant, CurrentGameParticipantDto>()
            .ForMember(d => d.ChampionId,
                o => o.MapFrom(s => DataDragon.Instance.GetChampionIdByKey(s.ChampionId)))
            .ForMember(d => d.Spell1Id,
                o => o.MapFrom(s => DataDragon.Instance.GetSpellByKey(s.Spell1Id.ToString()).Id))
            .ForMember(d => d.Spell2Id,
                o => o.MapFrom(s => DataDragon.Instance.GetSpellByKey(s.Spell2Id.ToString()).Id));
    }

    private static int ConvertTier(string tierText)
    {
        return tierText switch
        {
            "IRON" => 0,
            "BRONZE" => 1,
            "SILVER" => 2,
            "GOLD" => 3,
            "PLATINUM" => 4,
            "DIAMOND" => 5,
            "MASTER" => 6,
            "GRANDMASTER" => 7,
            "CHALLENGER" => 8,
            _ => -1
        };
    }

    private static int ConvertRank(string rankText)
    {
        return rankText switch
        {
            "I" => 1,
            "II" => 2,
            "III" => 3,
            "IV" => 4,
            _ => -1
        };
    }
}