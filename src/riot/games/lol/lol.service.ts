import { Injectable } from '@nestjs/common';
import { getSummonerByName } from './api/summoner/summoner';
import { RegionOfCountry } from 'src/riot/types/regions';
@Injectable()
export class LOLService {
  getHello(): string {
    return 'Held World!';
  }

  async getSummonerByName(summonerName: string, region: RegionOfCountry) {
    return await getSummonerByName(summonerName, region);
  }
}
