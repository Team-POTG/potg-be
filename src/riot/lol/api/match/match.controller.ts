import { Controller, Get, Param, Query } from "@nestjs/common";
import { MatchService } from "./match.service";
import { ApiParam, ApiQuery, ApiTags } from "@nestjs/swagger";
import { RegionOfContinent } from "../../types/regions";

@Controller()
export class MatchController {
  constructor(private matchService: MatchService) {}

  @Get("potg/lol/matches/by-puuid/:puuid")
  @ApiTags("Match")
  async getMatchListByPuuid() {}

  @Get("potg/lol/matches/:puuid")
  @ApiTags("Match")
  @ApiParam({
    name: "puuid",
    type: String,
  })
  @ApiQuery({
    name: "region",
    enum: RegionOfContinent,
  })
  async getMatch(
    @Param("puuid") puuid: string,
    @Query("region") region: RegionOfContinent
  ) {
    return this.matchService.getMatch(puuid);
  }
}
