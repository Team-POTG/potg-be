using Newtonsoft.Json;

namespace potg.RiotGames.Data;

public sealed record Spell
{
    [JsonProperty("id")]
    public string Id { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("description")]
    public string Description { get; init; }

    [JsonProperty("key")]
    public string Key { get; init; }
}