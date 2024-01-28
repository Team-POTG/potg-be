import { Controller, Param, Post, Query } from "@nestjs/common";
import { RegionOfCountry } from "src/potg/riot/common/types/regions";
import { ApiOperation, ApiParam, ApiQuery, ApiTags } from "@nestjs/swagger";
import { RequestService } from "./request.service";
import { RegionOfContinent } from "src/types/regions";

@Controller()
export class RequestController {
  constructor(private requestService: RequestService) {}

  @Post("potg/lol/request/by-puuid")
  @ApiOperation({ operationId: "requestByPuuid" })
  @ApiTags("Request")
  @ApiQuery({ name: "puuid", type: String })
  @ApiQuery({ name: "region", enum: RegionOfCountry })
  async requestByPuuid(
    @Query("puuid") puuid: string,
    @Query("region") region: RegionOfCountry
  ) {
    await this.requestService.requestByPuuid(puuid, region);
  }

  @Post("potg/lol/request/by-riot-id")
  @ApiOperation({ operationId: "requestByTagLineWithGameName" })
  @ApiTags("Request")
  @ApiQuery({ name: "tagLine", type: String })
  @ApiQuery({ name: "gameName", type: String })
  @ApiQuery({ name: "region", enum: RegionOfCountry })
  async requestByTagLineAnd(
    @Query("tagLine") tagLine: string,
    @Query("gameName") gameName: string,
    @Query("region") region: RegionOfCountry
  ) {
    await this.requestService.requestByTagLineWithGameName(
      tagLine,
      gameName,
      region
    );
  }
}
