import { Controller, Get, Param, Query, Req } from '@nestjs/common';
import { LOLService } from './lol.service';
import { RegionOfCountry } from 'src/riot/types/regions';
import { ApiParam, ApiQuery, ApiResponse, ApiTags } from '@nestjs/swagger';

@ApiTags('SummonerInfo')
@Controller()
export class LOLController {
  constructor(private readonly appService: LOLService) {}

  @Get('/summonerName/:summonerName')
  @ApiResponse({
    status: 400,
    description: 'Bad request',
  })
  @ApiResponse({ status: 401, description: 'Unauthorized' })
  @ApiResponse({ status: 403, description: 'Forbidden' })
  @ApiResponse({ status: 404, description: 'Data not found' })
  @ApiResponse({ status: 405, description: 'Method not allowed' })
  @ApiResponse({ status: 415, description: 'Unsupported media type' })
  @ApiResponse({ status: 429, description: 'Rate limit exceeded' })
  @ApiResponse({ status: 500, description: 'Internal server error' })
  @ApiResponse({ status: 502, description: 'Bad gateway' })
  @ApiResponse({ status: 503, description: 'Service unavailable' })
  @ApiResponse({ status: 504, description: 'Gateway timeout' })
  @ApiParam({
    name: 'summonerName',
    type: 'string',
  })
  @ApiQuery({
    name: 'region',
    enum: RegionOfCountry,
  })
  getSummonerByName(
    @Param('summonerName') summonerName: string,
    @Query('region') region: RegionOfCountry,
  ) {
    return this.appService.getSummonerByName(summonerName, region);
  }
}
