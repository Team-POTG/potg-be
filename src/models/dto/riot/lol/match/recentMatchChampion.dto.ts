import { Field, ObjectType } from "@nestjs/graphql";
import { BanDto } from "./ban.dto";
import { ObjectivesDto } from "./objectives.dto";
import { IsBoolean, IsNumber, IsString } from "class-validator";
import { ApiProperty } from "@nestjs/swagger";

export class RecentMatchChampionDto {
  @ApiProperty()
  @IsNumber()
  date: number;

  @ApiProperty()
  @IsNumber()
  championId: number;

  @ApiProperty()
  @IsString()
  championName: string;

  @ApiProperty()
  @IsNumber()
  kills: number;

  @ApiProperty()
  @IsNumber()
  deaths: number;

  @ApiProperty()
  @IsNumber()
  assists: number;

  @ApiProperty()
  @IsBoolean()
  isWin: boolean;
}
