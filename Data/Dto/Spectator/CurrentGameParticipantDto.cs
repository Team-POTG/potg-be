using Newtonsoft.Json;
using potg.Database.Entities;
using potg.RiotGames.Dto.Spectator;

namespace potg.Data.Dto.Spectator;

public sealed record CurrentGameParticipantDto
{
    [JsonProperty("teamId")]
    public int TeamId { get; init; }

    [JsonProperty("summonerId")]
    public string SummonerId { get; init; }

    [JsonProperty("summonerName")]
    public string SummonerName { get; init; }

    [JsonProperty("bot")]
    public bool Bot { get; init; }

    [JsonProperty("level")]
    public int Level { get; set; }

    [JsonProperty("spell1Id")]
    public string Spell1Id { get; init; }

    [JsonProperty("spell2Id")]
    public string Spell2Id { get; init; }

    [JsonProperty("championId")]
    public string ChampionId { get; init; }

    [JsonProperty("perks")]
    public Perks Perks { get; init; }

    [JsonProperty("ranks")]
    public List<LeagueRankEntity> Ranks { get; } = new();
}