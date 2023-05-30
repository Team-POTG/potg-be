using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match.Timeline;

public sealed record TimelineEntity
{
    [BsonElement("frameInterval")]
    public int FrameInterval { get; init; }

    [BsonElement("frames")]
    public IList<FrameEntity> Frames { get; init; }

    [BsonElement("gameId")]
    public long GameId { get; init; }

    [BsonElement("participants")]
    public IDictionary<string, string> Participants { get; init; }
}