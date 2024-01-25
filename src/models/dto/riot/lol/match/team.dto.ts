import { Field, ObjectType } from "@nestjs/graphql";
import { BanDto } from "./ban.dto";
import { ObjectivesDto } from "./objectives.dto";

@ObjectType()
export class TeamDto {
  @Field(() => [BanDto])
  bans: BanDto[];
  @Field()
  objectives: ObjectivesDto;
  @Field()
  teamId: number;
  @Field()
  win: boolean;
}
