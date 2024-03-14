import { Controller, Get, Param, Query } from "@nestjs/common";
import { RegionOfContinent, RegionOfCountry } from "../../types/regions";
import { AccountService } from "./account.service";
import {
  ApiOkResponse,
  ApiOperation,
  ApiParam,
  ApiQuery,
  ApiTags,
} from "@nestjs/swagger";
import { AccountDto } from "src/models/dto/riot/common/account.dto";
import { Account } from "src/models/schema/riot/common/account.schema";

@Controller()
export class AccountController {
  constructor(private accountService: AccountService) {}

  @Get("potg/common/accounts/by-riot-id")
  @ApiOperation({ operationId: "getAccountByGameNameWithTagLine" })
  @ApiTags("Account")
  @ApiQuery({
    name: "gameName",
    type: String,
  })
  @ApiQuery({
    name: "tagLine",
    type: String,
  })
  @ApiQuery({
    name: "region",
    enum: RegionOfCountry,
  })
  @ApiOkResponse({ type: Account })
  async getAccountByGameNameWithTagLine(
    @Query("tagLine") tagLine: string,
    @Query("gameName") gameName: string,
    @Query("region") region: RegionOfCountry
  ): Promise<AccountDto> {
    return this.accountService
      .getAccountByGameNameWithTagLine(tagLine, gameName, region)
      .then((data) => data);
  }

  @Get("potg/common/accounts/by-puuid")
  @ApiOperation({ operationId: "getAccountByPuuid" })
  @ApiTags("Account")
  @ApiQuery({
    name: "puuid",
    type: String,
  })
  @ApiQuery({
    name: "region",
    enum: RegionOfCountry,
  })
  @ApiOkResponse({ type: Account })
  async getAccountByPuuid(
    @Query("puuid") puuid: string,
    @Query("region") region: RegionOfCountry
  ): Promise<AccountDto> {
    return this.accountService
      .getAccountByPuuid(puuid, region)
      .then((data) => data);
  }
}
