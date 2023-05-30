using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record WardPlaceEvent : WardEvent
{
    [BsonElement("creatorId")]
    public byte CreatorId { get; init; }
}