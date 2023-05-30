using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace potg.Database.Entities.Match;

public sealed record ParticipantEntity
{
    [BsonElement("assists")]
    public long Assists { get; init; }

    [BsonElement("baronKills")]
    public long BaronKills { get; init; }

    [BsonElement("champLevel")]
    public long ChampLevel { get; init; }

    [BsonElement("championId")]
    public int ChampionId { get; init; }

    [BsonElement("championName")]
    public string ChampionName { get; init; }

    [BsonElement("damageDealtToBuildings")]
    public long DamageDealtToBuildings { get; init; }

    [BsonElement("damageDealtToObjectives")]
    public long DamageDealtToObjectives { get; init; }

    [BsonElement("damageDealtToTurrets")]
    public long DamageDealtToTurrets { get; init; }

    [BsonElement("damageSelfMitigated")]
    public long DamageSelfMitigated { get; init; }

    [BsonElement("deaths")]
    public long Deaths { get; init; }

    [BsonElement("detectorWardsPlaced")]
    public long DetectorWardsPlaced { get; init; }

    [BsonElement("doubleKills")]
    public long DoubleKills { get; init; }

    [BsonElement("dragonKills")]
    public long DragonKills { get; init; }

    [BsonElement("firstBloodKill")]
    public bool FirstBloodKill { get; init; }

    [BsonElement("firstTowerKill")]
    public bool FirstTowerKill { get; init; }

    [BsonElement("goldEarned")]
    public long GoldEarned { get; init; }

    [BsonElement("individualPosition")]
    public string IndividualPosition { get; init; }

    [BsonElement("inhibitorKills")]
    public long InhibitorKills { get; init; }

    [BsonElement("item0")]
    public long Item0 { get; init; }

    [BsonElement("item1")]
    public long Item1 { get; init; }

    [BsonElement("item2")]
    public long Item2 { get; init; }

    [BsonElement("item3")]
    public long Item3 { get; init; }

    [BsonElement("item4")]
    public long Item4 { get; init; }

    [BsonElement("item5")]
    public long Item5 { get; init; }

    [BsonElement("item6")]
    public long Item6 { get; init; }

    [BsonElement("killingSprees")]
    public long KillingSprees { get; init; }

    [BsonElement("kills")]
    public long Kills { get; init; }

    [BsonElement("lane")]
    public string Lane { get; init; }

    [BsonElement("largestKillingSpree")]
    public long LargestKillingSpree { get; init; }

    [BsonElement("largestMultiKill")]
    public long LargestMultiKill { get; init; }

    [BsonElement("longestTimeSpentLiving")]
    public long LongestTimeSpentLiving { get; init; }

    [BsonElement("magicDamageDealt")]
    public long MagicDamageDealt { get; init; }

    [BsonElement("magicDamageDealtToChampions")]
    public long MagicDamageDealtToChampions { get; init; }

    [BsonElement("magicDamageTaken")]
    public long MagicDamageTaken { get; init; }

    [BsonElement("neutralMinionsKilled")]
    public long NeutralMinionsKilled { get; init; }

    [BsonElement("nexusKills")]
    public long NexusKills { get; init; }

    [BsonElement("objectivesStolen")]
    public long ObjectivesStolen { get; init; }

    [BsonElement("participantId")]
    public long ParticipantId { get; init; }

    [BsonElement("pentaKills")]
    public long PentaKills { get; init; }

    [BsonElement("perks")]
    public PerksEntity Perks { get; init; }

    [BsonElement("physicalDamageDealt")]
    public long PhysicalDamageDealt { get; init; }

    [BsonElement("physicalDamageDealtToChampions")]
    public long PhysicalDamageDealtToChampions { get; init; }

    [BsonElement("physicalDamageTaken")]
    public long PhysicalDamageTaken { get; init; }

    [BsonElement("puuid")]
    public string Puuid { get; init; }

    [BsonElement("quadraKills")]
    public long QuadraKills { get; init; }

    [BsonElement("role")]
    public string Role { get; init; }

    [BsonElement("sightWardsBoughtInGame")]
    public long SightWardsBoughtInGame { get; init; }

    [BsonElement("summoner1Id")]
    public string Summoner1Id { get; init; }

    [BsonElement("summoner2Id")]
    public string Summoner2Id { get; init; }

    [BsonElement("summonerLevel")]
    public long SummonerLevel { get; init; }

    [BsonElement("summonerName")]
    public string SummonerName { get; init; }

    [BsonElement("teamId")]
    public long TeamId { get; init; }

    [BsonElement("totalDamageDealt")]
    public long TotalDamageDealt { get; init; }

    [BsonElement("totalDamageDealtToChampions")]
    public long TotalDamageDealtToChampions { get; init; }

    [BsonElement("totalDamageShieldedOnTeammates")]
    public long TotalDamageShieldedOnTeammates { get; init; }

    [BsonElement("totalDamageTaken")]
    public long TotalDamageTaken { get; init; }

    [BsonElement("totalHeal")]
    public long TotalHeal { get; init; }

    [BsonElement("totalHealsOnTeammates")]
    public long TotalHealsOnTeammates { get; init; }

    [BsonElement("totalMinionsKilled")]
    public long TotalMinionsKilled { get; init; }

    [BsonElement("totalUnitsHealed")]
    public long TotalUnitsHealed { get; init; }

    [BsonElement("tripleKills")]
    public long TripleKills { get; init; }

    [BsonElement("trueDamageDealt")]
    public long TrueDamageDealt { get; init; }

    [BsonElement("trueDamageDealtToChampions")]
    public long TrueDamageDealtToChampions { get; init; }

    [BsonElement("trueDamageTaken")]
    public long TrueDamageTaken { get; init; }

    [BsonElement("turretKills")]
    public long TurretKills { get; init; }

    [BsonElement("visionScore")]
    public long VisionScore { get; init; }

    [BsonElement("visionWardsBoughtInGame")]
    public long VisionWardsBoughtInGame { get; init; }

    [BsonElement("wardsKilled")]
    public long WardsKilled { get; init; }

    [BsonElement("wardsPlaced")]
    public long WardsPlaced { get; init; }

    [BsonElement("badges")]
    public IList<BadgeEntity> Badges { get; set; } = new List<BadgeEntity>();
}