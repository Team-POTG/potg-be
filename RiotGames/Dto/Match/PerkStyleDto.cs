using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public record PerkStyleDto
{
    [JsonProperty("description")]
    public string Description { get; init; }

    [JsonProperty("selections")]
    public IReadOnlyCollection<PerkStyleSelectionDto> Selections { get; init; }

    [JsonProperty("style")]
    public long StyleStyle { get; init; }
}