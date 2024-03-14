import { IsNumber, IsString } from "class-validator";
import { Observer } from "./observer.dto";
import { BannedChampion } from "./bannedChampion.dto";
import { ApiProperty } from "@nestjs/swagger";
import { CurrentGameParticipant } from "./currentGameParticipant.dto";

export class CurrentGameInfo {
  @IsNumber()
  @ApiProperty()
  gameId: number;

  @IsString()
  @ApiProperty()
  gameType: string;

  @IsNumber()
  @ApiProperty()
  gameStartTime: number;

  @IsNumber()
  @ApiProperty()
  mapId: number;

  @IsNumber()
  @ApiProperty()
  gameLength: number;

  @IsNumber()
  @ApiProperty()
  platformId: string;

  @IsString()
  @ApiProperty()
  gameMode: string;

  @ApiProperty({ type: [BannedChampion] })
  bannedChampions: BannedChampion[];

  @IsNumber()
  @ApiProperty()
  gameQueueConfigId: number;

  @ApiProperty()
  observers: Observer;

  @ApiProperty({ type: [CurrentGameParticipant] })
  participants: CurrentGameParticipant[];
}
