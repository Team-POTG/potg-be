using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record ObjectiveDto
{
    [JsonProperty("first")]
    public bool First { get; init; }

    [JsonProperty("kills")]
    public int Kills { get; init; }
}