using Newtonsoft.Json;

namespace potg.RiotGames.Dto.League;

public sealed record MiniSeriesDto
{
    [JsonProperty("losses")]
    public int Losses { get; init; }

    [JsonProperty("progress")]
    public string Progress { get; init; }

    [JsonProperty("target")]
    public int Target { get; init; }

    [JsonProperty("wins")]
    public int Wins { get; init; }
}