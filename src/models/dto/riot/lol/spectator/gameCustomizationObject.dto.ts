import { ApiProperty } from "@nestjs/swagger";
import { IsString } from "class-validator";

export class GameCustomizationObject {
  @IsString()
  @ApiProperty()
  category: string;

  @IsString()
  @ApiProperty()
  content: string;
}
