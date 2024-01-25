import { Field, ObjectType } from "@nestjs/graphql";
import { ParticipantDto } from "./participant.dto";
import { TeamDto } from "./team.dto";

@ObjectType()
export class InfoDto {
  @Field()
  gameCreation: number;
  @Field()
  gameDuration: number;
  @Field()
  gameEndTimestamp: number;
  @Field()
  gameId: number;
  @Field()
  gameMode: string;
  @Field()
  gameName: string;
  @Field()
  gameStartTimestamp: number;
  @Field()
  gameType: string;
  @Field()
  gameVersion: string;
  @Field()
  mapId: number;
  @Field()
  participants: ParticipantDto;
  @Field()
  platformId: string;
  @Field()
  queueId: number;
  @Field()
  teams: TeamDto;
  @Field()
  tournamentCode: string;
}
