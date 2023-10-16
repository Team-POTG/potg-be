import { Field, ObjectType } from "@nestjs/graphql";

@ObjectType()
export class MetadataDto {
  @Field()
  dataVersion: string;
  @Field()
  metchId: string;
  @Field((type) => [String])
  participants: string[];
}
