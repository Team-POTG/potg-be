using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events;

public record WardEvent : EventEntity
{
    [BsonElement("wardType")]
    public string WardType { get; init; }
}