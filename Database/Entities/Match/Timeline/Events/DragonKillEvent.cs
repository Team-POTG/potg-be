using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record DragonKillEvent : EliteMonsterKillEvent
{
    [BsonElement("monsterSubType")]
    public string MonsterSubType { get; init; }
}