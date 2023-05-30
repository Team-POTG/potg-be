using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events.Interfaces;

public interface IBountyAttachableEvent
{
    [BsonElement("bounty")]
    public long Bounty { get; init; }

    [BsonElement("shutdownBounty")]
    public long? ShutdownBounty { get; init; }
}