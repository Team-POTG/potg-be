import { Injectable } from "@nestjs/common";
import { RegionOfCountry } from "src/riot/games/lol/api/types/regions";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { Summoner } from "./api/schemas/summoner.schema";
import { log } from "console";
import { responseSummonerApiBySummonerName } from "./api/response/summoner";

@Injectable()
export class LOLService {
  constructor(
    @InjectModel(Summoner.name) private summonerModel: Model<Summoner>
  ) {}
  async getSummonerByName(
    summonerName: string,
    region: RegionOfCountry
  ): Promise<Summoner> {
    return await this.summonerModel
      .findOne({
        name: summonerName,
      })
      .exec();
  }

  async requestBySummonerName(summonerName: string, region: RegionOfCountry) {
    const summonerData = await responseSummonerApiBySummonerName(
      summonerName,
      region
    );

    log(summonerData);
    // summonerData의 puuid가 db에 존재하지 않으면 생성, 존재하면 업데이트
    await this.summonerModel
      .exists({ puuid: summonerData.puuid })
      .then(async () => {
        await this.summonerModel.findOneAndUpdate(
          { puuid: summonerData.puuid },
          summonerData
        );
      })
      .catch(async () => {
        await this.summonerModel.create(summonerData);
      });
  }
}
