using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record PerkStatsDto
{
    [JsonProperty("defense")]
    public long Defense { get; init; }

    [JsonProperty("flex")]
    public long Flex { get; init; }

    [JsonProperty("offense")]
    public long Offense { get; init; }
}