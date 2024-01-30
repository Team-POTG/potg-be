import { Field, ObjectType } from "@nestjs/graphql";
import { PerksDto } from "./perks.dto";

@ObjectType()
export class ParticipantDto {
  @Field()
  assists: number;
  @Field()
  baronKills: number;
  @Field()
  bountyLevel: number;
  @Field()
  champExperience: number;
  @Field()
  champLevel: number;
  @Field()
  championId: number;
  @Field()
  championName: string;
  @Field()
  championTransform: number;
  @Field()
  consumablesPurchased: number;
  @Field()
  damageDealtToBuildings: number;
  @Field()
  damageDealtToObjectives: number;
  @Field()
  damageDealtToTurrets: number;
  @Field()
  damageSelfMitigated: number;
  @Field()
  deaths: number;
  @Field()
  detectorWardsPlaced: number;
  @Field()
  doubleKills: number;
  @Field()
  dragonKills: number;
  @Field()
  firstBloodAssist: boolean;
  @Field()
  firstBloodKill: boolean;
  @Field()
  firstTowerAssist: boolean;
  @Field()
  firstTowerKill: boolean;
  @Field()
  gameEndedInEarlySurrender: boolean;
  @Field()
  gameEndedInSurrender: boolean;
  @Field()
  goldEarned: number;
  @Field()
  goldSpend: number;
  @Field()
  individualPosition: string;
  @Field()
  inhibitorKills: number;
  @Field()
  inhibitorTakedowns: number;
  @Field()
  inhibitorsLost: number;
  @Field()
  item0: number;
  @Field()
  item1: number;
  @Field()
  item2: number;
  @Field()
  item3: number;
  @Field()
  item4: number;
  @Field()
  item5: number;
  @Field()
  item6: number;
  @Field()
  itemsPurchased: number;
  @Field()
  killingSprees: number;
  @Field()
  kills: number;
  @Field()
  lane: string;
  @Field()
  largestCriticalStrike: number;
  @Field()
  largestKillingSpree: number;
  @Field()
  largestMulitiKill: number;
  @Field()
  longestTimeSpentLiving: number;
  @Field()
  magicDamageDealt: number;
  @Field()
  magicDamageDealtToChampions: number;
  @Field()
  magicDamageTaken: number;
  @Field()
  neutralMinionsKilled: number;
  @Field()
  nexusKills: number;
  @Field()
  nexusTakedowns: number;
  @Field()
  nexusLost: number;
  @Field()
  objectivesStolen: number;
  @Field()
  objectivesStolenAssists: number;
  @Field()
  participantId: number;
  @Field()
  pentaKills: number;
  @Field(() => PerksDto)
  perks: PerksDto;
  @Field()
  physicalDamageDealt: number;
  @Field()
  physicalDamageDealtToChampions: number;
  @Field()
  physicalDamageTaken: number;
  @Field()
  profileIcon: number;
  @Field()
  puuid: string;
  @Field()
  quadraKills: number;
  @Field()
  riotIdName: string;
  @Field()
  riotIdTagline: string;
  @Field()
  role: string;
  @Field()
  sightWardsBoughtInGame: number;
  @Field()
  spell1Casts: number;
  @Field()
  spell2Casts: number;
  @Field()
  spell3Casts: number;
  @Field()
  spell4Casts: number;
  @Field()
  summoner1Casts: number;
  @Field()
  summoner1Id: number;
  @Field()
  summoner2Casts: number;
  @Field()
  summoner2Id: number;
  @Field()
  summonerId: string;
  @Field()
  summonerLevel: number;
  @Field()
  summonerName: string;
  @Field()
  teamEarlySurrendered: boolean;
  @Field()
  teamId: number;
  @Field()
  teamPosition: string;
  @Field()
  timeCCingOthers: number;
  @Field()
  timePlayed: number;
  @Field()
  totalDamageDealt: number;
  @Field()
  totalDamageDealtToChampions: number;
  @Field()
  totalDamageShieldedOnTeammates: number;
  @Field()
  totalDamageTaken: number;
  @Field()
  totalHeal: number;
  @Field()
  totalHealsOnTeammates: number;
  @Field()
  totalMinionsKilled: number;
  @Field()
  totalTimeCCDealt: number;
  @Field()
  totalTimeSpentDead: number;
  @Field()
  totalUnitsHealed: number;
  @Field()
  tripleKills: number;
  @Field()
  trueDamageDealt: number;
  @Field()
  trueDamageDealtToChampions: number;
  @Field()
  trueDamageTaken: number;
  @Field()
  turretKills: number;
  @Field()
  turretTakedowns: number;
  @Field()
  turretsLost: number;
  @Field()
  unrealKills: number;
  @Field()
  visionScore: number;
  @Field()
  visionWardsBoughtInGame: number;
  @Field()
  wardsKilled: number;
  @Field()
  wardsPlaced: number;
  @Field()
  win: boolean;
}
