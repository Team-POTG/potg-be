import { Field, ObjectType } from "@nestjs/graphql";
import { PerkStatsDto } from "./perkStats.dto";
import { PerkStyleDto } from "./perkStyle.dto";

@ObjectType()
export class PerksDto {
  @Field()
  statPerks: PerkStatsDto;
  @Field((type) => [PerkStyleDto])
  styles: PerkStyleDto[];
}
