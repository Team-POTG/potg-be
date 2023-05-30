using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record MultiKillEvent : ChampionSpecialKillEvent
{
    [BsonElement("multiKillLength")]
    public int MultiKillLength { get; init; }
}