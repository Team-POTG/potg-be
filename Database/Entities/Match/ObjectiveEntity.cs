using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match;

public sealed record ObjectiveEntity
{
    [BsonElement("first")]
    public bool First { get; init; }

    [BsonElement("kills")]
    public int Kills { get; init; }
}