import { IsString } from "class-validator";

export class AccountDto {
  @IsString()
  puuid: string;

  @IsString()
  gameName?: string;

  @IsString()
  tagLine?: string;
}
