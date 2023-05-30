using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match;

public sealed record ObjectivesEntity
{
    [BsonElement("baron")]
    public ObjectiveEntity Baron { get; init; }

    [BsonElement("champion")]
    public ObjectiveEntity Champion { get; init; }

    [BsonElement("dragon")]
    public ObjectiveEntity Dragon { get; init; }

    [BsonElement("inhibitor")]
    public ObjectiveEntity Inhibitor { get; init; }

    [BsonElement("riftHerald")]
    public ObjectiveEntity RiftHerald { get; init; }

    [BsonElement("tower")]
    public ObjectiveEntity Tower { get; init; }
}