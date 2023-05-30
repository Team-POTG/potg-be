using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Entities.Match.Timeline.Events.Interfaces;
using potg.RiotGames.Data;

namespace potg.Database.Entities.Match.Timeline.Events;

public record ChampionSpecialKillEvent: KillEvent, IPositionalEvent
{
    public Position Position { get; init; }

    [BsonElement("killType")]
    public string KillType { get; init; }
}