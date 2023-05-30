using Newtonsoft.Json;
using potg.RiotGames.Dto.Spectator;

namespace potg.Data.Dto.Spectator;

public record CurrentGameDto
{
    [JsonProperty("gameId")]
    public long GameId { get; init; }

    [JsonProperty("mapId")]
    public int MapId { get; init; }

    [JsonProperty("gameQueueConfigId")]
    public int GameQueueConfigId { get; init; }

    [JsonProperty("teams")]
    public IList<CurrentGameTeamDto> Teams { get; init; }

    [JsonProperty("bannedChampions")]
    public IEnumerable<BannedChampion> BannedChampions { get; init; }

    [JsonProperty("gameStartTime")]
    public long GameStartTime { get; init; }
}