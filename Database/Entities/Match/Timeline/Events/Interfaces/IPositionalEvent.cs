using MongoDB.Bson.Serialization.Attributes;
using potg.RiotGames.Data;

namespace potg.Database.Entities.Match.Timeline.Events.Interfaces;

public interface IPositionalEvent
{
    [BsonElement("position")]
    public Position Position { get; init; }
}