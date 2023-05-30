using Newtonsoft.Json;

namespace potg.RiotGames.Data;

public sealed record ChampionInfo
{
    [JsonProperty("attack")]
    public int Attack { get; set; }

    [JsonProperty("defense")]
    public int Defense { get; set; }

    [JsonProperty("magic")]
    public int Magic { get; set; }

    [JsonProperty("difficulty")]
    public int Difficulty { get; set; }
}