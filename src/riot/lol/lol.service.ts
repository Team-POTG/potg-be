import { Injectable } from "@nestjs/common";
import { RegionOfCountry } from "src/riot/lol/types/regions";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { Summoner } from "./api/summoner/schemas/summoner.schema";
import {
  responseSummonerApiByPuuid,
  responseSummonerApiBySummonerName,
} from "./api/summoner/response";
import { log } from "console";
import { async } from "rxjs";

@Injectable()
export class LOLService {
  constructor() {} // @InjectModel(Summoner.name) private summonerModel: Model<Summoner>

  // async requestBySummonerName(summonerName: string, region: RegionOfCountry) {
  //   const summonerData = await responseSummonerApiBySummonerName(
  //     summonerName,
  //     region
  //   );

  //   // TODO: 분리하여 재활용하기
  //   // summonerData의 puuid가 db에 존재하지 않으면 생성, 존재하면 업데이트
  //   await this.summonerModel
  //     .findOneAndUpdate({ puuid: summonerData.puuid }, summonerData)
  //     .then(async (summoner) => {
  //       if (!summoner) await this.summonerModel.create(summonerData);
  //     });
  // }

  // async requestByPuuid(puuid: string, region: RegionOfCountry) {
  //   const summonerData = await responseSummonerApiByPuuid(puuid, region);

  //   // summonerData의 puuid가 db에 존재하지 않으면 생성, 존재하면 업데이트
  //   await this.summonerModel
  //     .exists({ puuid: summonerData.puuid })
  //     .then(async () => {
  //       await this.summonerModel.findOneAndUpdate(
  //         { puuid: summonerData.puuid },
  //         summonerData
  //       );
  //     })
  //     .catch(async () => {
  //       await this.summonerModel.create(summonerData);
  //     });
  // }
}
