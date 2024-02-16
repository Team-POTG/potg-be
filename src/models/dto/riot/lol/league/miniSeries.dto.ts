import { ApiProperty } from "@nestjs/swagger";
import { IsBoolean, IsNumber, IsString } from "class-validator";

export class MiniSeriesDto {
  @IsNumber()
  @ApiProperty()
  losses: number;

  @IsString()
  @ApiProperty()
  progress: string;

  @IsNumber()
  @ApiProperty()
  target: number;

  @IsNumber()
  @ApiProperty()
  wins: number;
}
