using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record InfoDto
{
    [JsonProperty("gameCreation")]
    public ulong GameCreation { get; init; }

    [JsonProperty("gameDuration")]
    public int GameDuration { get; init; }

    [JsonProperty("gameEndTimestamp")]
    public ulong GameEndTimestamp { get; init; }

    [JsonProperty("gameId")]
    public long GameId { get; init; }

    [JsonProperty("gameMode")]
    public string GameMode { get; init; }

    [JsonProperty("gameName")]
    public string GameName { get; init; }

    [JsonProperty("gameStartTimestamp")]
    public ulong GameStartTimestamp { get; init; }

    [JsonProperty("gameType")]
    public string GameType { get; init; }

    [JsonProperty("gameVersion")]
    public string GameVersion { get; init; }

    [JsonProperty("mapId")]
    public int MapId { get; init; }

    [JsonProperty("participants")]
    public IReadOnlyCollection<ParticipantsDto> Participants { get; init; }

    [JsonProperty("platformId")]
    public string PlatformId { get; init; }

    [JsonProperty("queueId")]
    public int QueueId { get; init; }

    [JsonProperty("teams")]
    public IReadOnlyCollection<TeamDto> Teams { get; init; }

    [JsonProperty("tournamentCode")]
    public string TournamentCode { get; init; }
}