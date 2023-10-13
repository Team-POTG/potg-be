import { Controller, Get, Param, Post, Query, Req } from "@nestjs/common";
import { LOLService } from "./lol.service";
import { RegionOfCountry } from "src/riot/games/lol/api/types/regions";
import { ApiParam, ApiQuery, ApiTags } from "@nestjs/swagger";
import { log } from "console";

@Controller()
export class LOLController {
  constructor(private readonly lolService: LOLService) {}

  @Get("summonerName/:summonerName")
  @ApiTags("SummonerInfo")
  @ApiParam({
    name: "summonerName",
    type: String,
  })
  @ApiQuery({
    name: "region",
    enum: RegionOfCountry,
  })
  async getSummonerByName(
    @Param("summonerName") summonerName: string,
    @Query("region") region: RegionOfCountry
  ) {
    return this.lolService
      .getSummonerByName(summonerName, region)
      .then((data) => data);
  }

  @Post("request/:summonerName")
  @ApiTags("Request")
  @ApiParam({
    name: "summonerName",
    type: String,
  })
  @ApiQuery({
    name: "region",
    enum: RegionOfCountry,
  })
  async requestBySummonerName(
    @Param("summonerName") summonerName: string,
    @Query("region") region: RegionOfCountry
  ) {
    await this.lolService.requestBySummonerName(summonerName, region);
  }
}
