using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match;

public sealed record PerkStatsEntity
{
    [BsonElement("defense")]
    public long Defense { get; init; }

    [BsonElement("flex")]
    public long Flex { get; init; }

    [BsonElement("offense")]
    public long Offense { get; init; }
}