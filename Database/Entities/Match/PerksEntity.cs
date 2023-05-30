using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match;

public sealed record PerksEntity
{
    [BsonElement("statPerks")]
    public PerkStatsEntity StatPerks { get; init; }

    [BsonElement("styles")]
    public IReadOnlyCollection<PerkStyleEntity> Styles { get; init; }
}