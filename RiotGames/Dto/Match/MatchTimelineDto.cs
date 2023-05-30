using Newtonsoft.Json;
using potg.Database.Entities.Match.Timeline;

namespace potg.RiotGames.Dto.Match;

public sealed record MatchTimelineDto
{
    [JsonProperty("metadata")]
    public MetadataDto Metadata { get; init; }

    [JsonProperty("info")]
    public TimelineInfoDto Info { get; init; }
}