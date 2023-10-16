import { Controller, Get, Param, Post, Query, Req } from "@nestjs/common";
import { LOLService } from "./lol.service";
import { RegionOfCountry } from "src/riot/lol/types/regions";
import { ApiConsumes, ApiParam, ApiQuery, ApiTags } from "@nestjs/swagger";
import { log } from "console";

@Controller()
export class LOLController {
  constructor(private lolService: LOLService) {}

  // @Post("potg/lol/request/by-name/:summonerName")
  // @ApiTags("Request")
  // @ApiParam({ name: "summonerName", type: String })
  // @ApiQuery({ name: "region", enum: RegionOfCountry })
  // async requestBySummonerName(
  //   @Param("summonerName") summonerName: string,
  //   @Query("region") region: RegionOfCountry
  // ) {
  //   await this.lolService.requestBySummonerName(summonerName, region);
  // }

  // @Post("potg/lol/request/by-puuid/:puuid")
  // @ApiTags("Request")
  // @ApiParam({ name: "puuid", type: String })
  // @ApiQuery({ name: "region", enum: RegionOfCountry })
  // async requestByPuuid(
  //   @Param("puuid") puuid: string,
  //   @Query("region") region: RegionOfCountry
  // ) {
  //   await this.lolService;
  // }
}
