using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record GameEndEvent : EventEntity
{
    [BsonElement("realTimestamp")]
    public long RealTimestamp { get; init; }

    [BsonElement("gameId")]
    public long GameId { get; init; }

    [BsonElement("winningTeam")]
    public int WinningTeam { get; init; }
}