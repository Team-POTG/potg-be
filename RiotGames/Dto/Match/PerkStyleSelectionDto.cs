using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record PerkStyleSelectionDto
{
    [JsonProperty("perk")]
    public long Perk { get; init; }

    [JsonProperty("var1")]
    public long Var1 { get; init; }

    [JsonProperty("var2")]
    public long Var2 { get; init; }

    [JsonProperty("var3")]
    public long Var3 { get; init; }
}