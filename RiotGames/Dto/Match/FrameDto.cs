using Newtonsoft.Json;
using potg.Data.Converters;

namespace potg.RiotGames.Dto.Match;

public sealed record FrameDto
{
    [JsonProperty("events")]
    public IReadOnlyList<EventDto> Events { get; init; }

    [JsonProperty("participantFrames")]
    public IReadOnlyDictionary<string, ParticipantFrameDto> ParticipantFrames { get; init; }

    [JsonProperty("timestamp")]
    public ulong Timestamp { get; init; }
}