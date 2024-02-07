import { ApiProperty } from "@nestjs/swagger";
import { IsNumber } from "class-validator";

export class Perks {
  @IsNumber()
  @ApiProperty()
  perkIds: number[];

  @IsNumber()
  @ApiProperty()
  perkStyle: number;

  @IsNumber()
  @ApiProperty()
  perkSubStyle: number;
}
