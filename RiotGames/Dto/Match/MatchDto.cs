using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public record MatchDto
{
    [JsonProperty("metadata")]
    public MetadataDto Metadata { get; init; }

    [JsonProperty("info")]
    public InfoDto Info { get; init; }
}