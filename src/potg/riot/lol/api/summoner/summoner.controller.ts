import { Controller, Get, Param, Query } from "@nestjs/common";
import { RegionOfCountry } from "src/potg/riot/common/types/regions";
import {
  ApiOkResponse,
  ApiOperation,
  ApiParam,
  ApiProperty,
  ApiQuery,
  ApiResponse,
  ApiResponseProperty,
  ApiTags,
} from "@nestjs/swagger";
import { SummonerService } from "./summoner.service";
import { SummonerDto } from "./dto/summoner.dto";
import { Summoner, SummonerSchema } from "./schema/summoner.schema";

@Controller()
export class SummonerController {
  constructor(private summonerService: SummonerService) {}

  @Get("potg/lol/summoner/by-puuid/:puuid")
  @ApiOperation({ operationId: "getSummonerByPuuid" })
  @ApiTags("Summoner")
  @ApiParam({ name: "puuid", type: String })
  @ApiQuery({ name: "region", enum: RegionOfCountry })
  @ApiOkResponse({ type: Summoner })
  async getSummonerByPuuid(
    @Param("puuid") puuid: string,
    @Query("region") region: RegionOfCountry
  ): Promise<SummonerDto> {
    return this.summonerService
      .getSummonerByPuuid(puuid, region)
      .then((data) => data);
  }
}
