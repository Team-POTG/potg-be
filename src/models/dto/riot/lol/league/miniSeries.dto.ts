import { IsBoolean, IsNumber, IsString } from "class-validator";

export class MiniSeriesDto {
  @IsNumber()
  losses: number;

  @IsString()
  progress: string;

  @IsNumber()
  target: number;

  @IsNumber()
  wins: number;
}
