using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events.Interfaces;

public interface IParticipatableEvent
{
    [BsonElement("participantId")]
    public byte ParticipantId { get; init; }
}