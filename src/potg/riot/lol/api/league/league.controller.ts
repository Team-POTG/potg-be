import { Controller, Get, Param, Query } from "@nestjs/common";
import {
  ApiOkResponse,
  ApiOperation,
  ApiParam,
  ApiQuery,
  ApiTags,
} from "@nestjs/swagger";
import {
  RegionOfContinent,
  RegionOfCountry,
} from "../../../common/types/regions";
import { LeagueService } from "./league.service";
import { League } from "src/models/schema/riot/lol/league/league.schema";
import { LeagueEntryDto } from "src/models/dto/riot/lol/league/leagueEntry.dto";

@Controller()
export class LeagueController {
  constructor(private leagueService: LeagueService) {}

  @Get("potg/lol/league/by-summoner/:id")
  @ApiOperation({ operationId: "getLeague" })
  @ApiTags("League")
  @ApiParam({
    name: "id",
    type: String,
  })
  @ApiQuery({
    name: "region",
    enum: RegionOfCountry,
  })
  @ApiOkResponse({ type: [LeagueEntryDto] })
  async getLeague(
    @Param("id") id: string,
    @Query("region") region: RegionOfCountry
  ) {
    return this.leagueService.find(id);
  }
}
