import { Controller, Get, Param, Query } from "@nestjs/common";
import { MatchService } from "./match.service";
import { ApiOperation, ApiParam, ApiQuery, ApiTags } from "@nestjs/swagger";
import { RegionOfContinent } from "../../../common/types/regions";

@Controller()
export class MatchController {
  constructor(private matchService: MatchService) {}

  @Get("potg/lol/matches/by-puuid/:puuid")
  @ApiOperation({ operationId: "getMatch" })
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
    // @Query("region") region: RegionOfContinent
    @Param("count") count: number
  ) {
    return this.matchService.getMatch(puuid, count);
  }
}
