using Newtonsoft.Json;

namespace potg.Database.Entities.Match.Timeline;

public sealed record FrameEntity
{
    [JsonProperty("events")]
    public List<EventEntity> Events { get; init; } = new();

    [JsonProperty("participantFrames")]
    public IDictionary<string, ParticipantFrameEntity> ParticipantFrames { get; init; }

    [JsonProperty("timestamp")]
    public long Timestamp { get; init; }
}