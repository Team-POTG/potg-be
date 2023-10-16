import { Controller, Get, Param, Post, Query, Req } from "@nestjs/common";
// import { LOLService } from "./lol.service";
import { RegionOfCountry } from "src/riot/lol/types/regions";
import { ApiConsumes, ApiParam, ApiQuery, ApiTags } from "@nestjs/swagger";
import { log } from "console";
import { SummonerService } from "./summoner.service";

@Controller()
export class SummonerController {
  constructor(private summonerService: SummonerService) {}

  @Get("potg/lol/summoner/by-name/:summonerName")
  @ApiTags("Summoner")
  @ApiParam({ name: "summonerName", type: String })
  @ApiQuery({ name: "region", enum: RegionOfCountry })
  async getSummonerByName(
    @Param("summonerName") summonerName: string,
    @Query("region") region: RegionOfCountry
  ) {
    return this.summonerService
      .getSummonerByName(summonerName, region)
      .then((data) => data);
  }

  @Get("potg/lol/summoner/by-puuid/:puuid")
  @ApiTags("Summoner")
  @ApiParam({ name: "puuid", type: String })
  @ApiQuery({ name: "region", enum: RegionOfCountry })
  async getSummonerByPuuid(
    @Param("puuid") puuid: string,
    @Query("region") region: RegionOfCountry
  ) {
    return this.summonerService
      .getSummonerByPuuid(puuid, region)
      .then((data) => data);
  }
}
