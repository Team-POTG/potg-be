using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match;

public sealed record TeamEntity
{
    [BsonElement("teamId")]
    public int TeamId { get; init; }

    [BsonElement("bans")]
    public IReadOnlyCollection<BanEntity> Bans { get; init; }

    [BsonElement("objectives")]
    public ObjectivesEntity Objectives { get; init; }

    [BsonElement("win")]
    public bool Win { get; init; }

    [BsonElement("participants")]
    public IReadOnlyList<ParticipantEntity> Participants { get; set; }
}