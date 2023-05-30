using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events.Interfaces;

public interface ILaneSpecificEvent
{
    [BsonElement("laneType")]
    public string LaneType { get; init; }
}