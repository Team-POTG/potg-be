using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Interfaces;

namespace potg.Database.Entities.Match;

public sealed record MatchEntity : IMongoEntity
{
    [BsonId]
    public ObjectId Id { get; init; } = ObjectId.GenerateNewId();

    [BsonElement("matchId")]
    public string MatchId { get; init; }

    [BsonElement("participants")]
    public IReadOnlyCollection<string> Puuids { get; init; }

    [BsonElement("gameDuration")]
    public int GameDuration { get; init; }

    [BsonElement("gameEndTimestamp")]
    public ulong GameEndTimestamp { get; init; }

    [BsonElement("gameId")]
    public long GameId { get; init; }

    [BsonElement("gameMode")]
    public string GameMode { get; init; }

    [BsonElement("gameType")]
    public string GameType { get; init; }

    [BsonElement("gameVersion")]
    public string GameVersion { get; init; }

    [BsonElement("mapId")]
    public int MapId { get; init; }

    [BsonElement("platformId")]
    public string PlatformId { get; init; }

    [BsonElement("queueId")]
    public int QueueId { get; init; }

    [BsonElement("teams")]
    public IReadOnlyCollection<TeamEntity> Teams { get; init; }
}