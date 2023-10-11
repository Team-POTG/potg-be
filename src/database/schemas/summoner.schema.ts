import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";
import { Document, HydratedDocument } from "mongoose";

export type SummonerDocument = HydratedDocument<Summoner>;

@Schema()
export class Summoner {
  @Prop()
  accountId: string;

  @Prop()
  profileIconId: number;

  @Prop()
  revisionDate: number;

  @Prop()
  name: string;

  @Prop()
  id: string;

  @Prop()
  puuid: string;

  @Prop()
  summonerLevel: number;
}

export const SummonerSchema = SchemaFactory.createForClass(Summoner);
