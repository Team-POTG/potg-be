using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Entities.Match.Timeline.Events.Interfaces;

namespace potg.Database.Entities.Match.Timeline.Events;

public record ItemEvent : EventEntity, IParticipatableEvent
{
    [BsonElement("itemId")]
    public int ItemId { get; init; }

    public byte ParticipantId { get; init; }
}