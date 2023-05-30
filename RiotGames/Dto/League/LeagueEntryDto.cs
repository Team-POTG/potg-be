using Newtonsoft.Json;
using potg.Data.Converters;

namespace potg.RiotGames.Dto.League;

public sealed record LeagueEntryDto
{
    [JsonProperty("leagueId")]
    public string LeagueId { get; init; }

    [JsonProperty("summonerId")]
    public string SummonerId { get; init; }

    [JsonProperty("summonerName")]
    public string SummonerName { get; init; }

    [JsonProperty("queueType")]
    public string QueueType { get; init; }

    [JsonProperty("tier")]
    public string Tier { get; init; }

    [JsonProperty("rank")]
    public string Rank { get; init; }

    [JsonProperty("leaguePoints")]
    public int LeaguePoints { get; init; }

    [JsonProperty("wins")]
    public int Wins { get; init; }

    [JsonProperty("losses")]
    public int Losses { get; init; }

    [JsonProperty("hotStreak")]
    public bool IsHotStreak { get; init; }

    [JsonProperty("veteran")]
    public bool IsVeteran { get; init; }

    [JsonProperty("freshBlood")]
    public bool IsFreshBlood { get; init; }

    [JsonProperty("inactive")]
    public bool IsInactive { get; init; }

    [JsonProperty("miniSeries")]
    public MiniSeriesDto MiniSeries { get; init; }
}