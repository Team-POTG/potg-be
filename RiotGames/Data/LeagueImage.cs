using Newtonsoft.Json;

namespace potg.RiotGames.Data;

public sealed record LeagueImage
{
    [JsonProperty("full")]
    public string Full { get; init; }

    [JsonProperty("sprite")]
    public string Sprite { get; init; }

    [JsonProperty("group")]
    public string Group { get; init; }

    [JsonProperty("x")]
    public int X { get; init; }

    [JsonProperty("y")]
    public int Y { get; init; }

    [JsonProperty("w")]
    public int Width { get; init; }

    [JsonProperty("h")]
    public int Height { get; init; }
}