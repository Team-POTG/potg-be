import { Field, ObjectType } from "@nestjs/graphql";
import { ObjectiveDto } from "./objective.dto";

@ObjectType()
export class ObjectivesDto {
  @Field()
  baron: ObjectiveDto;
  @Field()
  champion: ObjectiveDto;
  @Field()
  dragon: ObjectiveDto;
  @Field()
  inhibitor: ObjectiveDto;
  @Field()
  riftHerald: ObjectiveDto;
  @Field()
  tower: ObjectiveDto;
}
