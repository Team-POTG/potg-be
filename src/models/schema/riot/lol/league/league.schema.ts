import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";
import { HydratedDocument } from "mongoose";
import { LeagueEntryDto } from "src/models/dto/riot/lol/league/leagueEntry.dto";

export type LeagueDocument = HydratedDocument<League>;

@Schema()
export class League {
  @Prop()
  info: LeagueEntryDto[];
}

export const LeagueSchema = SchemaFactory.createForClass(League);
