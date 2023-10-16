import { Get, Injectable } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { Summoner } from "../summoner/schemas/summoner.schema";
import { MatchDto } from "./dto/match.dto";
import { RegionOfContinent } from "../../types/regions";
import { responseMatchByMatchId } from "./response";
import { Match } from "./schemas/match.schema";

@Injectable()
export class MatchService {
  constructor(@InjectModel(Match.name) private matchModel: Model<Match>) {}

  async getMatch(puuid: string): Promise<MatchDto[]> {
    return await this.matchModel
      .find({ "info.participants.puuid": puuid })
      .exec();
  }
}
