import { Controller, Get, Param, Query } from "@nestjs/common";
import { AutocompleteService } from "./autocomplete.service";
import {
  ApiOkResponse,
  ApiOperation,
  ApiParam,
  ApiQuery,
  ApiTags,
} from "@nestjs/swagger";
import { AccountDto } from "src/models/dto/riot/common/account.dto";
import { SummonerDto } from "src/models/dto/riot/lol/summoner/summoner.dto";

@Controller("autocomplete")
export class AutocompleteController {
  constructor(private autocompleteService: AutocompleteService) {}

  @Get("potg/common/autocomplete/by-riot-id")
  @ApiOperation({ operationId: "getAutocompleteByRiotId" })
  @ApiTags("Autocomplete")
  @ApiQuery({
    name: "tagLine",
    type: String,
    required: false,
  })
  @ApiQuery({
    name: "gameName",
    type: String,
  })
  @ApiQuery({
    name: "limit",
    type: Number,
  })
  @ApiOkResponse({ type: [SummonerDto] })
  async getAutocompleteByRiotId(
    @Query("tagLine") tagLine: string,
    @Query("gameName") gameName: string,
    @Query("limit") limit: number = 5
  ): Promise<
    {
      gameName: string;
      tagLine: string;
      profileIconId: number;
      tier: string;
      rank: string;
    }[]
  > {
    return this.autocompleteService.getAutocompleteByRiotId(
      tagLine,
      gameName,
      limit
    );
  }
}
