import { MaxLength, IsString, IsNumber, Length } from "class-validator";

export class SummonerDto {
  @MaxLength(56)
  @IsString()
  accountId: string;

  @IsNumber()
  profileIconId: number;

  @IsNumber()
  revisionDate: number;

  @IsString()
  name: string;

  @MaxLength(63)
  @IsString()
  id: string;

  @Length(78)
  @IsString()
  puuid: string;

  @IsNumber()
  summonerLevel: number;
}
