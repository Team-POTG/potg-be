using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Entities.Match.Timeline.Events.Interfaces;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record DragonSoulEvent : EventEntity, ITeamEvent
{
    [BsonElement("name")]
    public string Name { get; init; }

    public byte TeamId { get; init; }
}