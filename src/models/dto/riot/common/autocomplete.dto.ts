import { ApiProperty } from "@nestjs/swagger";
import { MaxLength, IsString, IsNumber, Length } from "class-validator";

export class AutocompleteDto {
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
  tier: string;

  @ApiProperty()
  @IsString()
  rank: string;

  @ApiProperty()
  @IsNumber()
  leaguePoint: number;
}
