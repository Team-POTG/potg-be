using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline.Events.Interfaces;

public interface IAssistableEvent
{
    [BsonElement("assistingParticipantIds")]
    public IEnumerable<long>? AssistingParticipantIds { get; init; }
}