using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities;

public sealed record LeagueRankEntity
{
    [BsonElement("leagueId")]
    public string LeagueId { get; init; }

    [BsonElement("queueType")]
    public string QueueType { get; init; }

    [BsonElement("tier")]
    public int Tier { get; init; }

    [BsonElement("rank")]
    public int Rank { get; init; }

    [BsonElement("leaguePoints")]
    public int LeaguePoints { get; init; }

    [BsonElement("wins")]
    public int Wins { get; init; }

    [BsonElement("losses")]
    public int Losses { get; init; }

    [BsonElement("miniSeries")]
    [BsonIgnoreIfNull]
    public MiniSeriesEntity? MiniSeries { get; init; }
}