using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Entities.Match.Timeline.Events.Interfaces;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record LevelUpEvent : EventEntity, IParticipatableEvent
{
    public byte ParticipantId { get; init; }

    [BsonElement("level")]
    public byte Level { get; init; }
}