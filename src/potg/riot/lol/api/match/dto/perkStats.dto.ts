import { Field, ObjectType } from "@nestjs/graphql";

@ObjectType()
export class PerkStatsDto {
  @Field()
  defense: number;
  @Field()
  flex: number;
  @Field()
  offense: number;
}
