using Newtonsoft.Json;

namespace potg.RiotGames.Data;

public sealed record ChampionDescription
{
    [JsonProperty("id")]
    public string Id { get; init; }

    [JsonProperty("key")]
    public int Key { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("title")]
    public string Title { get; init; }

    [JsonProperty("blurb")]
    public string Blurb { get; init; }

    [JsonProperty("info")]
    public ChampionInfo Info { get; init; }

    [JsonProperty("image")]
    public LeagueImage Image { get; init; }

    [JsonProperty("tags")]
    public IReadOnlyList<string> Tags { get; init; }

    [JsonProperty("partype")]
    public string Partype { get; init; }

    [JsonProperty("stats")]
    public IReadOnlyDictionary<string, double> Stats { get; init; }
}