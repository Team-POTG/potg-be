import { Field, ObjectType } from "@nestjs/graphql";
import { InfoDto } from "./info.dto";
import { MetadataDto } from "./metadata.dto";

@ObjectType()
export class MatchDto {
  @Field(() => MetadataDto)
  metadata: MetadataDto;
  @Field(() => InfoDto)
  info: InfoDto;
}
