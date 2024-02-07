import { Controller, Get, Param, Query } from "@nestjs/common";
import {
  ApiExtraModels,
  ApiOkResponse,
  ApiOperation,
  ApiParam,
  ApiQuery,
  ApiResponse,
  ApiTags,
  getSchemaPath,
} from "@nestjs/swagger";
import { SpectatorService } from "./spectator.service";
import { RegionOfCountry } from "src/types/regions";
import { CurrentGameInfo } from "src/models/dto/riot/lol/spectator/currentGameInfo.dto";
import { CurrentGameParticipant } from "src/models/dto/riot/lol/spectator/currentGameParticipant.dto";

@Controller()
export class SpectatorController {
  constructor(private spectatorService: SpectatorService) {}

  @Get("potg/lol/spectator/by-summoner")
  @ApiOperation({ operationId: "getSpectator" })
  @ApiExtraModels(CurrentGameInfo)
  @ApiTags("Spectator")
  @ApiQuery({
    name: "summonerId",
    type: String,
  })
  @ApiQuery({
    name: "region",
    enum: RegionOfCountry,
  })
  // @ApiOkResponse({ type: CurrentGameInfo })
  @ApiOkResponse({
    type: CurrentGameInfo,
    // schema: { $ref: getSchemaPath(CurrentGameParticipant) },
  })
  async getSpectator(
    @Query("summonerId") summonerId: string,
    @Query("region") region: RegionOfCountry
  ): Promise<CurrentGameInfo> {
    return await this.spectatorService.getSpectator(summonerId, region);
  }
}
