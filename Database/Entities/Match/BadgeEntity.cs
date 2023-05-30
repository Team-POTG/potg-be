using MongoDB.Bson.Serialization.Attributes;
using potg.Data.Types;

namespace potg.Database.Entities.Match;

public record BadgeEntity
{
    public BadgeEntity(BadgeRarity rarity, string name, string description)
    {
        Rarity = rarity;
        Name = name;
        Description = description;
    }

    [BsonElement("rarity")]
    public BadgeRarity Rarity { get; }

    [BsonElement("name")]
    public string Name { get; }

    [BsonElement("description")]
    public string Description { get; }
}