import { IsBoolean, IsNumber, IsString } from "class-validator";
import { MiniSeriesDto } from "./miniSeries.dto";

export class LeagueEntryDto {
  @IsString()
  leagueId: string;

  @IsString()
  summonerId: string;

  @IsString()
  summonerName: string;

  @IsString()
  queueType: string;

  @IsString()
  tier: string;

  @IsString()
  rank: string;

  @IsNumber()
  leaguePoints: number;

  @IsNumber()
  wins: number;

  @IsNumber()
  losses: number;

  @IsBoolean()
  hotStreak: boolean;

  @IsBoolean()
  veteran: boolean;

  @IsBoolean()
  freshBlood: boolean;

  @IsBoolean()
  inactive: boolean;

  miniSeries: MiniSeriesDto;
}
