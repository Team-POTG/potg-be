using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Entities.Match.Timeline.Events.Interfaces;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record SkillLevelUpEvent : EventEntity, IParticipatableEvent
{
    public byte ParticipantId { get; init; }

    [BsonElement("levelUpType")]
    public string LevelUpType { get; init; }

    [BsonElement("skillSlot")]
    public int SkillSlot { get; init; }
}