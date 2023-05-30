using Newtonsoft.Json;

namespace potg.Data.Dto.Spectator;

public sealed record CurrentGameTeamDto
{
    [JsonProperty("teamId")]
    public int TeamId { get; init; }

    public IList<CurrentGameParticipantDto> Participants { get; init; }
}