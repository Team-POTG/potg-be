import { IsNumber, IsString, Length, MaxLength } from 'class-validator';
import { ApiProperty } from '@nestjs/swagger';

export class SummonerDTO {
  @ApiProperty()
  @MaxLength(56)
  @IsString()
  accountId: string;

  @ApiProperty()
  @IsNumber()
  profileIconId: number;

  @ApiProperty()
  @IsNumber()
  revisionDate: number;

  @ApiProperty()
  @IsString()
  name: string;

  @ApiProperty()
  @MaxLength(63)
  @IsString()
  id: string;

  @ApiProperty()
  @Length(78)
  @IsString()
  puuid: string;

  @ApiProperty()
  @IsNumber()
  summonerLevel: number;
}
