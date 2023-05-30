using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Entities.Match.Timeline.Events.Interfaces;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record ChampionTransformEvent : EventEntity, IParticipatableEvent
{
    public byte ParticipantId { get; init; }

    [BsonElement("transformType")]
    public string TransformType { get; init; }
}