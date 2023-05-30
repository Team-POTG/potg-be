using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record PauseEndEvent : EventEntity
{
    [BsonElement("realTimestamp")]
    public long RealTimestamp { get; init; }
}