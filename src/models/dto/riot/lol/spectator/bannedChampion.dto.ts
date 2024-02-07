import { ApiProperty } from "@nestjs/swagger";
import { IsNumber } from "class-validator";

export class BannedChampion {
  @IsNumber()
  @ApiProperty()
  pickTurn: number;

  @IsNumber()
  @ApiProperty()
  championId: number;

  @IsNumber()
  @ApiProperty()
  teamId: number;
}
