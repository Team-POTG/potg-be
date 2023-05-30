using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match;

public sealed record BanEntity
{
    [BsonElement("championId")]
    public int ChampionId { get; init; }

    [BsonElement("championName")]
    public string ChampionName { get; init; }

    [BsonElement("pickTurn")]
    public int PickTurn { get; init; }
}