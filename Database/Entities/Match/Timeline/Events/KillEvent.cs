using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events;

public record KillEvent : EventEntity
{
    [BsonElement("killerId")]
    public long KillerId { get; set; }
}