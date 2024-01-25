import { Field, ObjectType } from "@nestjs/graphql";

@ObjectType()
export class MetadataDto {
  @Field()
  dataVersion: string;
  @Field()
  matchId: string;
  @Field((type) => [String])
  participants: string[];
}
