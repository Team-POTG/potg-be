import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";
import { ApiProperty } from "@nestjs/swagger";
import { HydratedDocument } from "mongoose";

export type LeagueDocument = HydratedDocument<League>;

@Schema()
export class League {
  @Prop()
  @ApiProperty()
  accountId: string;

  @Prop()
  @ApiProperty()
  profileIconId: number;

  @Prop()
  @ApiProperty()
  revisionDate: number;

  @Prop()
  @ApiProperty()
  name: string;

  @Prop()
  @ApiProperty()
  id: string;

  @Prop()
  @ApiProperty()
  puuid: string;

  @Prop()
  @ApiProperty()
  summonerLevel: number;
}

export const LeagueSchema = SchemaFactory.createForClass(League);
