using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Interfaces;

namespace potg.Database.Entities;

public sealed record SummonerEntity : IMongoEntity
{
	[BsonId]
	public ObjectId Id { get; init; }

	[BsonElement("region")]
	public string Region { get; init; } = "asia";

	[BsonElement("subRegion")]
	public string SubRegion { get; init; } = "kr";

	[BsonElement("encryptedSummonerId")]
	public string EncryptedSummonerId { get; init; }

	[BsonElement("accountId")]
	public string AccountId { get; init; }

	[BsonElement("puuid")]
	public string Puuid { get; init; }

	[BsonElement("level")]
	public int Level { get; init; }

	[BsonElement("name")]
	public string Name { get; init; }

	[BsonElement("searchName")]
	public string SearchName { get; init; }

	[BsonElement("profileIconId")]
	public int ProfileIconId { get; init; }

	[BsonElement("lastUpdate")]
	public DateTime LastUpdate { get; init; }

	[BsonElement("lastUpdateEpoch")]
	public ulong LastUpdateEpoch { get; init; }

	[BsonElement("ranks")]
	public List<LeagueRankEntity> Ranks { get; init; }
}