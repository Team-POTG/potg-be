using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Summoner;

public record SummonerDto
{
    [JsonProperty("accountId")]
    public string AccountId { get; set; }

    [JsonProperty("profileIconId")]
    public int ProfileIconId { get; set; }

    [JsonProperty("revisionDate")]
    public ulong RevisionDate { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("puuid")]
    public string Puuid { get; set; }

    [JsonProperty("summonerLevel")]
    public int SummonerLevel { get; set; }
}