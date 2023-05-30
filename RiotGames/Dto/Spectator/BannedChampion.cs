using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Spectator;

public sealed record BannedChampion
{
    [JsonProperty("championId")]
    public int ChampionId { get; init; }

    [JsonProperty("teamId")]
    public int TeamId { get; init; }

    [JsonProperty("pickTurn")]
    public int PickTurn { get; init; }
}