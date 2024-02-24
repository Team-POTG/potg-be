import { ApiProperty } from "@nestjs/swagger";
import { IsString, IsNumber, IsOptional } from "class-validator";

export class AutocompleteDto {
  @ApiProperty()
  @IsString()
  puuid: string;

  @ApiProperty()
  @IsString()
  gameName: string;

  @ApiProperty()
  @IsString()
  tagLine: string;

  @ApiProperty()
  @IsNumber()
  profileIconId: number;

  @ApiProperty()
  @IsNumber()
  summonerLevel: number;

  @ApiProperty()
  @IsString()
  @IsOptional()
  tier?: string | undefined;

  @ApiProperty()
  @IsString()
  @IsOptional()
  rank?: string | undefined;

  @ApiProperty()
  @IsNumber()
  @IsOptional()
  leaguePoint?: number | undefined;
}
