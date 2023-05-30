using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match;

public sealed record PerkStyleSelectionEntity
{
    [BsonElement("perk")]
    public long Perk { get; init; }

    [BsonElement("var1")]
    public long Var1 { get; init; }

    [BsonElement("var2")]
    public long Var2 { get; init; }

    [BsonElement("var3")]
    public long Var3 { get; init; }
}