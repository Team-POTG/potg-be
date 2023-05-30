using Newtonsoft.Json;

namespace potg.RiotGames.Data;

public record struct Position
{
    [JsonProperty("x")]
    public long X { get; init; }

    [JsonProperty("y")]
    public long Y { get; init; }
}