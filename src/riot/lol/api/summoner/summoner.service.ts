import { Injectable } from "@nestjs/common";
import { RegionOfCountry } from "src/riot/lol/types/regions";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { Summoner } from "./schemas/summoner.schema";
import { SummonerDto } from "./dto/summoner.dto";

@Injectable()
export class SummonerService {
  constructor(
    @InjectModel(Summoner.name) private summonerModel: Model<Summoner>
  ) {}
  async getSummonerByName(
    summonerName: string,
    region: RegionOfCountry
  ): Promise<SummonerDto> {
    return await this.summonerModel
      .findOne({
        name: summonerName,
      })
      .exec();
  }

  async getSummonerByPuuid(
    puuid: string,
    region: RegionOfCountry
  ): Promise<SummonerDto> {
    return await this.summonerModel.findOne({ puuid: puuid }).exec();
  }
}
