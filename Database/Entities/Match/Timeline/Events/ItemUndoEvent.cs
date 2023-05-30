using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record ItemUndoEvent : ItemEvent
{
    [BsonElement("afterId")]
    public long AfterId { get; init; }

    [BsonElement("beforeId")]
    public long BeforeId { get; init; }

    [BsonElement("goldGain")]
    public long GoldGain { get; init; }
}