import { Field, ObjectType } from "@nestjs/graphql";

@ObjectType()
export class ObjectiveDto {
  @Field()
  first: boolean;
  @Field()
  kills: number;
}
