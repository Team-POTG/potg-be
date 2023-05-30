using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Spectator;

public sealed record Perks
{
    [JsonProperty("perkIds")]
    public IEnumerable<int> PerkIds { get; init; }

    [JsonProperty("perkStyle")]
    public int PerkStyle { get; init; }

    [JsonProperty("perkSubStyle")]
    public int PerkSubStyle { get; init; }
}