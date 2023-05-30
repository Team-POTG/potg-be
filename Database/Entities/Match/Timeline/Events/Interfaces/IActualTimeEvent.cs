using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events.Interfaces;

public interface IActualTimeEvent
{
    [BsonElement("actualStartTime")]
    public long ActualStartTime { get; init; }
}