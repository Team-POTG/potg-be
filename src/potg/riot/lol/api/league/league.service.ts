import { Injectable } from "@nestjs/common";
import { InjectConnection, InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { RegionOfCountry } from "../../../common/types/regions";
import { responseLeagueBySummonerId } from "./response";
import { League } from "./schema/league.schema";

@Injectable()
export class LeagueService {
  constructor(@InjectModel(League.name) private leagueModel: Model<League>) {}

  async getLeague(id: string, region: RegionOfCountry) {
    return await this.leagueModel.create(
      await responseLeagueBySummonerId(id, region)
    );
  }
}
