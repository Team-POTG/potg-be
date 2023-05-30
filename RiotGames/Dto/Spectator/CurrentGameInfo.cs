using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Spectator;

public sealed record CurrentGameInfo
{
    [JsonProperty("gameId")]
    public long GameId { get; init; }

    [JsonProperty("mapId")]
    public int MapId { get; init; }

    [JsonProperty("gameQueueConfigId")]
    public int GameQueueConfigId { get; init; }

    [JsonProperty("participants")]
    public IEnumerable<CurrentGameParticipant> Participants { get; init; }
    
    [JsonProperty("bannedChampions")]
    public IEnumerable<BannedChampion> BannedChampions { get; init; }

    [JsonProperty("gameStartTime")]
    public long GameStartTime { get; init; }
}