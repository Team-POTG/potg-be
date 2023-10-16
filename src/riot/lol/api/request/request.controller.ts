import { Controller, Param, Post, Query } from "@nestjs/common";
import { RegionOfCountry } from "src/riot/lol/types/regions";
import { ApiParam, ApiQuery, ApiTags } from "@nestjs/swagger";
import { RequestService } from "./request.service";

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
