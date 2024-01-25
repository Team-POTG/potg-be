import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";
import { MetadataDto } from "../dto/metadata.dto";
import { InfoDto } from "../dto/info.dto";
import { HydratedDocument } from "mongoose";

export type MatchDocument = HydratedDocument<Match>;

@Schema()
export class Match {
  @Prop()
  metadata!: MetadataDto;

  @Prop()
  info!: InfoDto;
}

export const MatchSchema = SchemaFactory.createForClass(Match);
