import { Field, ObjectType } from "@nestjs/graphql";
import { PerkStyleSelectionDto } from "./perkStyleSelection.dto";

@ObjectType()
export class PerkStyleDto {
  @Field()
  description: string;
  @Field((type) => [PerkStyleSelectionDto])
  selections: PerkStyleSelectionDto[];
  @Field()
  style: number;
}
