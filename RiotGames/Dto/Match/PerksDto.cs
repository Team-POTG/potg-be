using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record PerksDto
{
    [JsonProperty("statPerks")]
    public PerkStatsDto StatPerks { get; init; }

    [JsonProperty("styles")]
    public IReadOnlyCollection<PerkStyleDto> Styles { get; init; }
}