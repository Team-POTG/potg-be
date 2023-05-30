using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities;

public sealed record MiniSeriesEntity
{
    [BsonElement("losses")]
    public int Losses { get; init; }

    [BsonElement("progress")]
    public string Progress { get; init; }

    [BsonElement("target")]
    public int Target { get; init; }

    [BsonElement("wins")]
    public int Wins { get; init; }
}