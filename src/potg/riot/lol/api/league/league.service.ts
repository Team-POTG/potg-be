import { Injectable } from "@nestjs/common";
import { InjectConnection, InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { RegionOfCountry } from "../../../common/types/regions";
import { responseLeagueBySummonerId } from "./response";
import { League } from "src/models/schema/riot/lol/league/league.schema";
import { LeagueEntryDto } from "src/models/dto/riot/lol/league/leagueEntry.dto";

@Injectable()
export class LeagueService {
  constructor(@InjectModel(League.name) private leagueModel: Model<League>) {}

  async getLeaguesBySummonerId(
    summonerId: string,
    region: RegionOfCountry
  ): Promise<LeagueEntryDto[]> {
    return await this.leagueModel
      .findOne({ "info.summonerId": summonerId })
      .then(async (leagues) => {
        if (leagues) return leagues.info;
        else
          return this.leagueModel
            .create({
              info: await responseLeagueBySummonerId(summonerId, region),
            })
            .then((createdLeagues) => createdLeagues.info);
      });
  }

  async updateLeaguesBySummonerId(
    summonerId: string,
    region: RegionOfCountry
  ): Promise<LeagueEntryDto[]> {
    return await this.leagueModel.findOneAndUpdate(
      { "info.summonerId": summonerId },
      { info: await responseLeagueBySummonerId(summonerId, region) }
    );
  }
}
