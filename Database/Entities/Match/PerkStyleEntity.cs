using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match;

public record PerkStyleEntity
{
    [BsonElement("description")]
    public string Description { get; init; }

    [BsonElement("selections")]
    public IReadOnlyCollection<PerkStyleSelectionEntity> Selections { get; init; }

    [BsonElement("style")]
    public long StyleStyle { get; init; }
}