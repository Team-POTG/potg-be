import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";
import { HydratedDocument } from "mongoose";
import { InfoDto } from "src/models/dto/riot/lol/match/info.dto";
import { MetadataDto } from "src/models/dto/riot/lol/match/metadata.dto";

export type MatchDocument = HydratedDocument<Match>;

@Schema()
export class Match {
  @Prop()
  metadata: MetadataDto;

  @Prop()
  info: InfoDto;
}

export const MatchSchema = SchemaFactory.createForClass(Match);
