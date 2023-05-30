using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record ParticipantDto
{
    [JsonProperty("participantId")]
    public long ParticipantId { get; init; }

    [JsonProperty("puuid")]
    public string Puuid { get; init; }
}