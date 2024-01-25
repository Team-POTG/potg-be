import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";
import { ApiProperty } from "@nestjs/swagger";
import { MaxLength, IsString, IsNumber, Length } from "class-validator";
import { HydratedDocument } from "mongoose";

export type SummonerDocument = HydratedDocument<Summoner>;

@Schema()
export class Summoner {
  @Prop()
  @ApiProperty()
  accountId!: string;

  @Prop()
  @ApiProperty()
  profileIconId!: number;

  @Prop()
  @ApiProperty()
  revisionDate!: number;

  @Prop()
  @ApiProperty()
  name!: string;

  @Prop()
  @ApiProperty()
  id!: string;

  @Prop()
  @ApiProperty()
  puuid!: string;

  @Prop()
  @ApiProperty()
  summonerLevel!: number;
}

export const SummonerSchema = SchemaFactory.createForClass(Summoner);
