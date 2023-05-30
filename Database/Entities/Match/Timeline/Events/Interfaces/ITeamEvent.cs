using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events.Interfaces;

public interface ITeamEvent
{

    [BsonElement("teamId")]
    public byte TeamId { get; init; }
}