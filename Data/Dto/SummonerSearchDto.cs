using Newtonsoft.Json;

namespace potg.Data.Dto;

public sealed record SummonerSearchDto
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("tier")]
    public int? Tier { get; set; }

    [JsonProperty("rank")]
    public int? Rank { get; set; }

    [JsonProperty("leaguePoint")]
    public int? LeaguePoint { get; set; }

    [JsonProperty("level")]
    public int? Level { get; set; }

    [JsonProperty("profileIcon")]
    public int? ProfileIcon { get; set; }
}