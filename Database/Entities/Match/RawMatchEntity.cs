using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Entities.Match.Timeline;
using potg.Database.Interfaces;
using potg.RiotGames.Dto.Match;

namespace potg.Database.Entities.Match;

public sealed record RawMatchEntity : MatchDto, IMongoEntity
{
    [BsonId]
    public ObjectId Id { get; init; } = ObjectId.GenerateNewId();

    [BsonElement("timeline")]
    public TimelineEntity Timeline { get; set; }
}