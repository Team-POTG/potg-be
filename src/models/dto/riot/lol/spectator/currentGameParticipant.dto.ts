import { IsBoolean, IsNumber, IsString } from "class-validator";
import { GameCustomizationObject } from "./gameCustomizationObject.dto";
import { Perks } from "./perks.dto";
import { ApiProperty } from "@nestjs/swagger";
import { Type } from "class-transformer";

export class CurrentGameParticipant {
  @IsNumber()
  @ApiProperty()
  championId: number;

  @ApiProperty()
  perks: Perks;

  @IsNumber()
  @ApiProperty()
  profileIconId: number;

  @IsBoolean()
  @ApiProperty()
  bot: boolean;

  @IsNumber()
  @ApiProperty()
  teamId: number;

  @IsString()
  @ApiProperty()
  summonerName: string;

  @IsString()
  @ApiProperty()
  summonerId: string;

  @IsString()
  @ApiProperty()
  puuid: string;

  @IsNumber()
  @ApiProperty()
  spell1Id: number;

  @IsNumber()
  @ApiProperty()
  spell2Id: number;

  @ApiProperty({ type: [GameCustomizationObject] })
  gameCustomizationObjects: GameCustomizationObject[];
}
