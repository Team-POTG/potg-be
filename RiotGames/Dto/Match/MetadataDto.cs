using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record MetadataDto
{
    [JsonProperty("dataVersion")]
    public string DataVersion { get; init; }

    [JsonProperty("matchId")]
    public string MatchId { get; init; }

    [JsonProperty("participants")]
    public IReadOnlyCollection<string> Participants { get; init; }
}