import { Field, ObjectType } from "@nestjs/graphql";

@ObjectType()
export class PerkStyleSelectionDto {
  @Field()
  perk: number;
  @Field()
  var1: number;
  @Field()
  var2: number;
  @Field()
  var3: number;
}
