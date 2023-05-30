using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record TimelineInfoDto
{
    [JsonProperty("frameInterval")]
    public int FrameInterval { get; init; }

    [JsonProperty("frames")]
    public FrameDto[] Frames { get; init; }

    [JsonProperty("gameId")]
    public long GameId { get; init; }

    [JsonProperty("participants")]
    public IEnumerable<ParticipantDto> Participants { get; init; }
}