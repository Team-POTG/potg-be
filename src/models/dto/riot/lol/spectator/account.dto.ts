import { ApiProperty } from "@nestjs/swagger";
import { IsString } from "class-validator";

export class AccountDto {
  @ApiProperty()
  @IsString()
  tagLine: string;

  @ApiProperty()
  @IsString()
  gameName: string;
}
