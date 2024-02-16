import { Injectable } from "@nestjs/common";
import { InjectConnection, InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { RegionOfCountry } from "../../../common/types/regions";
import { responseLeagueBySummonerId } from "./response";
import { League } from "src/models/schema/riot/lol/league/league.schema";

@Injectable()
export class LeagueService {
  constructor(@InjectModel(League.name) private leagueModel: Model<League>) {}

  async find(id: string) {
    return await this.leagueModel.find({ summonerId: id }).exec();
  }

  async add(id: string, region: RegionOfCountry) {
    await this.leagueModel.create({
      info: await responseLeagueBySummonerId(id, region),
    });
  }

  async update(id: string, region: RegionOfCountry) {
    await this.leagueModel.updateOne({
      info: await responseLeagueBySummonerId(id, region),
    });
  }
}
