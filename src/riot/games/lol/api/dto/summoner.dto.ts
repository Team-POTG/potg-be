import { Schema, SchemaFactory } from "@nestjs/mongoose";
import { ApiProperty } from "@nestjs/swagger";
import { MaxLength, IsString, IsNumber, Length } from "class-validator";
import { HydratedDocument } from "mongoose";

export type SummonerDocument = HydratedDocument<SummonerDto>;

@Schema()
export class SummonerDto {
  @ApiProperty()
  @MaxLength(56)
  @IsString()
  accountId: string;

  @ApiProperty()
  @IsNumber()
  profileIconId: number;

  @ApiProperty()
  @IsNumber()
  revisionDate: number;

  @ApiProperty()
  @IsString()
  name: string;

  @ApiProperty()
  @MaxLength(63)
  @IsString()
  id: string;

  @ApiProperty()
  @Length(78)
  @IsString()
  puuid: string;

  @ApiProperty()
  @IsNumber()
  summonerLevel: number;
}
