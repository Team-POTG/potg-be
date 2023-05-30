using Newtonsoft.Json;
using potg.Data.Dto.Spectator;
using potg.Database.Entities;

namespace potg.Data.Dto;

public sealed record SummonerDto
{
    [JsonProperty("region")]
    public string Region { get; init; }

    [JsonProperty("subRegion")]
    public string SubRegion { get; init; }

    [JsonProperty("encryptedSummonerId")]
    public string EncryptedSummonerId { get; init; }

    [JsonProperty("accountId")]
    public string AccountId { get; init; }

    [JsonProperty("puuid")]
    public string Puuid { get; init; }

    [JsonProperty("level")]
    public int Level { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("searchName")]
    public string SearchName { get; init; }

    [JsonProperty("profileIconId")]
    public int ProfileIconId { get; init; }

    [JsonProperty("lastUpdate")]
    public DateTime LastUpdate { get; init; }

    [JsonProperty("lastUpdateEpoch")]
    public ulong LastUpdateEpoch { get; init; }

    [JsonProperty("ranks")]
    public List<LeagueRankEntity> Ranks { get; init; }

    [JsonProperty("currentGame")]
    public CurrentGameDto CurrentGame { get; init; }
}