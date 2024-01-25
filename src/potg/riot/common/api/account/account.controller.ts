import { Controller, Get, Param, Query } from "@nestjs/common";
import { RegionOfContinent } from "../../types/regions";
import { AccountService } from "./account.service";
import {
  ApiOkResponse,
  ApiOperation,
  ApiParam,
  ApiQuery,
  ApiTags,
} from "@nestjs/swagger";
import { Account } from "./schema/account.schema";

@Controller()
export class AccountController {
  constructor(private accountService: AccountService) {}

  @Get("potg/common/accounts/by-riot-id/:gameName/:tagLine")
  @ApiOperation({ operationId: "getAccountByGameNameWithTagLine" })
  @ApiTags("Riot Common")
  @ApiParam({
    name: "gameName",
    type: String,
  })
  @ApiParam({
    name: "tagLine",
    type: String,
  })
  @ApiQuery({
    name: "region",
    enum: RegionOfContinent,
  })
  @ApiOkResponse({ type: Account })
  async getAccountByGameNameWithTagLine(
    @Param("tagLine") tagLine: string,
    @Param("gameName") gameName: string,
    @Query("region") region: RegionOfContinent
  ) {
    return this.accountService.getAccountByGameNameWithTagLine(
      tagLine,
      gameName,
      region
    );
  }
}
