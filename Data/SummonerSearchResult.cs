using Newtonsoft.Json;

namespace potg.Data;

public sealed record SummonerSearchResult([property: JsonProperty("name")] string Name,
                                   [property: JsonProperty("tier")] int Tier,
                                   [property: JsonProperty("rank")] int Rank,
                                   [property: JsonProperty("leaguePoint")] int Lp,
                                   [property: JsonProperty("level")] int Level,
                                   [property: JsonProperty("profileIcon")] int ProfileIcon);