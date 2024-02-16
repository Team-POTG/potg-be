import { IsBoolean, IsNumber, IsString } from "class-validator";
import { MiniSeriesDto } from "./miniSeries.dto";
import { ApiProperty } from "@nestjs/swagger";

export class LeagueEntryDto {
  @IsString()
  @ApiProperty()
  leagueId: string;

  @IsString()
  @ApiProperty()
  summonerId: string;

  @IsString()
  @ApiProperty()
  summonerName: string;

  @IsString()
  @ApiProperty()
  queueType: string;

  @IsString()
  @ApiProperty()
  tier: string;

  @IsString()
  @ApiProperty()
  rank: string;

  @IsNumber()
  @ApiProperty()
  leaguePoints: number;

  @IsNumber()
  @ApiProperty()
  wins: number;

  @IsNumber()
  @ApiProperty()
  losses: number;

  @IsBoolean()
  @ApiProperty()
  hotStreak: boolean;

  @IsBoolean()
  @ApiProperty()
  veteran: boolean;

  @IsBoolean()
  @ApiProperty()
  freshBlood: boolean;

  @IsBoolean()
  @ApiProperty()
  inactive: boolean;

  @ApiProperty()
  miniSeries: MiniSeriesDto;
}
