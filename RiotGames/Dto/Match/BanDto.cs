using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record BanDto
{
    [JsonProperty("championId")]
    public int ChampionId { get; init; }

    [JsonProperty("pickTurn")]
    public int PickTurn { get; init; }
}