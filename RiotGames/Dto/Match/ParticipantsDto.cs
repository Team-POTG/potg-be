using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record ParticipantsDto
{
    [JsonProperty("assists")]
    public int Assists { get; init; }

    [JsonProperty("baronKills")]
    public int BaronKills { get; init; }

    [JsonProperty("basicPings")]
    public int BasicPings { get; init; }

    [JsonProperty("bountyLevel")]
    public int BountyLevel { get; init; }

    [JsonProperty("challenges")]
    public IReadOnlyDictionary<string, double> Challenges { get; init; }

    [JsonProperty("champExperience")]
    public int ChampExperience { get; init; }

    [JsonProperty("champLevel")]
    public int ChampLevel { get; init; }

    [JsonProperty("championId")]
    public int ChampionId { get; init; }

    [JsonProperty("championName")]
    public string ChampionName { get; init; }

    [JsonProperty("championTransform")]
    public int ChampionTransform { get; init; }

    [JsonProperty("consumablesPurchased")]
    public int ConsumablesPurchased { get; init; }

    [JsonProperty("damageDealtToBuildings")]
    public int DamageDealtToBuildings { get; init; }

    [JsonProperty("damageDealtToObjectives")]
    public int DamageDealtToObjectives { get; init; }

    [JsonProperty("damageDealtToTurrets")]
    public int DamageDealtToTurrets { get; init; }

    [JsonProperty("damageSelfMitigated")]
    public int DamageSelfMitigated { get; init; }

    [JsonProperty("deaths")]
    public int Deaths { get; init; }

    [JsonProperty("detectorWardsPlaced")]
    public int DetectorWardsPlaced { get; init; }

    [JsonProperty("doubleKills")]
    public int DoubleKills { get; init; }

    [JsonProperty("dragonKills")]
    public int DragonKills { get; init; }

    [JsonProperty("eligibleForProgression")]
    public bool EligibleForProgression { get; init; }

    [JsonProperty("firstBloodAssist")]
    public bool FirstBloodAssist { get; init; }

    [JsonProperty("firstBloodKill")]
    public bool FirstBloodKill { get; init; }

    [JsonProperty("firstTowerAssist")]
    public bool FirstTowerAssist { get; init; }

    [JsonProperty("firstTowerKill")]
    public bool FirstTowerKill { get; init; }

    [JsonProperty("gameEndedInEarlySurrender")]
    public bool GameEndedInEarlySurrender { get; init; }

    [JsonProperty("gameEndedInSurrender")]
    public bool GameEndedInSurrender { get; init; }

    [JsonProperty("goldEarned")]
    public int GoldEarned { get; init; }

    [JsonProperty("goldSpent")]
    public int GoldSpent { get; init; }

    [JsonProperty("individualPosition")]
    public string IndividualPosition { get; init; }

    [JsonProperty("inhibitorKills")]
    public int InhibitorKills { get; init; }

    [JsonProperty("inhibitorTakedowns")]
    public int InhibitorTakedowns { get; init; }

    [JsonProperty("inhibitorsLost")]
    public int InhibitorsLost { get; init; }

    [JsonProperty("item0")]
    public int Item0 { get; init; }

    [JsonProperty("item1")]
    public int Item1 { get; init; }

    [JsonProperty("item2")]
    public int Item2 { get; init; }

    [JsonProperty("item3")]
    public int Item3 { get; init; }

    [JsonProperty("item4")]
    public int Item4 { get; init; }

    [JsonProperty("item5")]
    public int Item5 { get; init; }

    [JsonProperty("item6")]
    public int Item6 { get; init; }

    [JsonProperty("itemsPurchased")]
    public int ItemsPurchased { get; init; }

    [JsonProperty("killingSprees")]
    public int KillingSprees { get; init; }

    [JsonProperty("kills")]
    public int Kills { get; init; }

    [JsonProperty("lane")]
    public string Lane { get; init; }

    [JsonProperty("largestCriticalStrike")]
    public int LargestCriticalStrike { get; init; }

    [JsonProperty("largestKillingSpree")]
    public int LargestKillingSpree { get; init; }

    [JsonProperty("largestMultiKill")]
    public int LargestMultiKill { get; init; }

    [JsonProperty("intestTimeSpentLiving")]
    public int intestTimeSpentLiving { get; init; }

    [JsonProperty("magicDamageDealt")]
    public int MagicDamageDealt { get; init; }

    [JsonProperty("magicDamageDealtToChampions")]
    public int MagicDamageDealtToChampions { get; init; }

    [JsonProperty("magicDamageTaken")]
    public int MagicDamageTaken { get; init; }

    [JsonProperty("neutralMinionsKilled")]
    public int NeutralMinionsKilled { get; init; }

    [JsonProperty("nexusKills")]
    public int NexusKills { get; init; }

    [JsonProperty("nexusLost")]
    public int NexusLost { get; init; }

    [JsonProperty("nexusTakedowns")]
    public int NexusTakedowns { get; init; }

    [JsonProperty("objectivesStolen")]
    public int ObjectivesStolen { get; init; }

    [JsonProperty("objectivesStolenAssists")]
    public int ObjectivesStolenAssists { get; init; }

    [JsonProperty("participantId")]
    public int ParticipantId { get; init; }

    [JsonProperty("pentaKills")]
    public int PentaKills { get; init; }

    [JsonProperty("perks")]
    public PerksDto Perks { get; init; }

    [JsonProperty("physicalDamageDealt")]
    public int PhysicalDamageDealt { get; init; }

    [JsonProperty("physicalDamageDealtToChampions")]
    public int PhysicalDamageDealtToChampions { get; init; }

    [JsonProperty("physicalDamageTaken")]
    public int PhysicalDamageTaken { get; init; }

    [JsonProperty("profileIcon")]
    public int ProfileIcon { get; init; }

    [JsonProperty("puuid")]
    public string Puuid { get; init; }

    [JsonProperty("quadraKills")]
    public int QuadraKills { get; init; }

    [JsonProperty("riotIdName")]
    public string RiotIdName { get; init; }

    [JsonProperty("riotIdTagline")]
    public string RiotIdTagline { get; init; }

    [JsonProperty("role")]
    public string Role { get; init; }

    [JsonProperty("sightWardsBoughtInGame")]
    public int SightWardsBoughtInGame { get; init; }

    [JsonProperty("spell1Casts")]
    public int Spell1Casts { get; init; }

    [JsonProperty("spell2Casts")]
    public int Spell2Casts { get; init; }

    [JsonProperty("spell3Casts")]
    public int Spell3Casts { get; init; }

    [JsonProperty("spell4Casts")]
    public int Spell4Casts { get; init; }

    [JsonProperty("summoner1Casts")]
    public int Summoner1Casts { get; init; }

    [JsonProperty("summoner1Id")]
    public string Summoner1Id { get; init; }

    [JsonProperty("summoner2Casts")]
    public int Summoner2Casts { get; init; }

    [JsonProperty("summoner2Id")]
    public string Summoner2Id { get; init; }

    [JsonProperty("summonerId")]
    public string SummonerId { get; init; }

    [JsonProperty("summonerLevel")]
    public int SummonerLevel { get; init; }

    [JsonProperty("summonerName")]
    public string SummonerName { get; init; }

    [JsonProperty("teamEarlySurrendered")]
    public bool TeamEarlySurrendered { get; init; }

    [JsonProperty("teamId")]
    public int TeamId { get; init; }

    [JsonProperty("teamPosition")]
    public string TeamPosition { get; init; }

    [JsonProperty("timeCCingOthers")]
    public int TimeCCingOthers { get; init; }

    [JsonProperty("timePlayed")]
    public int TimePlayed { get; init; }

    [JsonProperty("totalDamageDealt")]
    public int TotalDamageDealt { get; init; }

    [JsonProperty("totalDamageDealtToChampions")]
    public int TotalDamageDealtToChampions { get; init; }

    [JsonProperty("totalDamageShieldedOnTeammates")]
    public int TotalDamageShieldedOnTeammates { get; init; }

    [JsonProperty("totalDamageTaken")]
    public int TotalDamageTaken { get; init; }

    [JsonProperty("totalHeal")]
    public int TotalHeal { get; init; }

    [JsonProperty("totalHealsOnTeammates")]
    public int TotalHealsOnTeammates { get; init; }

    [JsonProperty("totalMinionsKilled")]
    public int TotalMinionsKilled { get; init; }

    [JsonProperty("totalTimeCCDealt")]
    public int TotalTimeCcDealt { get; init; }

    [JsonProperty("totalTimeSpentDead")]
    public int TotalTimeSpentDead { get; init; }

    [JsonProperty("totalUnitsHealed")]
    public int TotalUnitsHealed { get; init; }

    [JsonProperty("tripleKills")]
    public int TripleKills { get; init; }

    [JsonProperty("trueDamageDealt")]
    public int TrueDamageDealt { get; init; }

    [JsonProperty("trueDamageDealtToChampions")]
    public int TrueDamageDealtToChampions { get; init; }

    [JsonProperty("trueDamageTaken")]
    public int TrueDamageTaken { get; init; }

    [JsonProperty("turretKills")]
    public int TurretKills { get; init; }

    [JsonProperty("turretTakedowns")]
    public int TurretTakedowns { get; init; }

    [JsonProperty("turretsLost")]
    public int TurretsLost { get; init; }

    [JsonProperty("unrealKills")]
    public int UnrealKills { get; init; }

    [JsonProperty("visionScore")]
    public int VisionScore { get; init; }

    [JsonProperty("visionWardsBoughtInGame")]
    public int VisionWardsBoughtInGame { get; init; }

    [JsonProperty("wardsKilled")]
    public int WardsKilled { get; init; }

    [JsonProperty("wardsPlaced")]
    public int WardsPlaced { get; init; }

    [JsonProperty("win")]
    public bool Win { get; init; }
}