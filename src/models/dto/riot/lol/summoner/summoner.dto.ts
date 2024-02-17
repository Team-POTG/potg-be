import { ApiProperty } from "@nestjs/swagger";
import { MaxLength, IsString, IsNumber, Length } from "class-validator";

export class SummonerDto {
  @MaxLength(56)
  @IsString()
  @ApiProperty()
  accountId: string;

  @IsNumber()
  @ApiProperty()
  profileIconId: number;

  @IsNumber()
  @ApiProperty()
  revisionDate: number;

  @IsString()
  @ApiProperty()
  name: string;

  @MaxLength(63)
  @IsString()
  @ApiProperty()
  id: string;

  @Length(78)
  @IsString()
  @ApiProperty()
  puuid: string;

  @IsNumber()
  @ApiProperty()
  summonerLevel: number;
}
