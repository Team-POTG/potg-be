using MongoDB.Bson.Serialization.Attributes;
using potg.RiotGames.Types;

namespace potg.Database.Entities.Match.Timeline;

public record EventEntity
{
    [BsonElement("timestamp")]
    public long Timestamp { get; init; }

    [BsonElement("type")]
    public EventType Type { get; init; }
}