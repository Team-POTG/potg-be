import { Controller, Get, Param, Query } from "@nestjs/common";
import { AutocompleteService } from "./autocomplete.service";
import {
  ApiOkResponse,
  ApiOperation,
  ApiParam,
  ApiQuery,
  ApiTags,
} from "@nestjs/swagger";

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
  @ApiOkResponse({})
  async getAutocompleteByRiotId(
    @Query("tagLine") tagLine: string,
    @Query("gameName") gameName: string
  ) {
    return this.autocompleteService.getAutocompleteByRiotId(tagLine, gameName);
  }
}
