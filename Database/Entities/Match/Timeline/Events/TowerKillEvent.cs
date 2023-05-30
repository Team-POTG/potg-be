using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record TowerKillEvent : BuildingKillEvent
{
    [BsonElement("towerType")]
    public string TowerType { get; init; }
}