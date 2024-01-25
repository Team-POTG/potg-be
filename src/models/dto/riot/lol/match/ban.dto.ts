import { Field, ObjectType } from "@nestjs/graphql";

@ObjectType()
export class BanDto {
  @Field()
  championId: number;
  @Field()
  pickTurn: number;
}
