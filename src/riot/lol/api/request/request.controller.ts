import { Controller, Get, Param, Post, Query, Req } from "@nestjs/common";
import { RegionOfCountry } from "src/riot/lol/types/regions";
import { ApiConsumes, ApiParam, ApiQuery, ApiTags } from "@nestjs/swagger";
import { log } from "console";
import { RequestService } from "./RequestService";
import { SummonerService } from "../summoner/summoner.service";

@Controller()
export class RequestController {
  constructor(private requestService: RequestService) {}

  @Post("potg/lol/request/by-name/:summonerName")
  @ApiTags("Request")
  @ApiParam({ name: "summonerName", type: String })
  @ApiQuery({ name: "region", enum: RegionOfCountry })
  async requestBySummonerName(
    @Param("summonerName") summonerName: string,
    @Query("region") region: RegionOfCountry
  ) {
    await this.requestService.requestBySummonerName(summonerName, region);
  }

  @Post("potg/lol/request/by-puuid/:puuid")
  @ApiTags("Request")
  @ApiParam({ name: "puuid", type: String })
  @ApiQuery({ name: "region", enum: RegionOfCountry })
  async requestByPuuid(
    @Param("puuid") puuid: string,
    @Query("region") region: RegionOfCountry
  ) {
    await this.requestService;
  }
}
