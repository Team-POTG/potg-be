import { Injectable } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { MatchDto } from "src/models/dto/riot/lol/match/match.dto";
import { Match } from "src/models/schema/riot/lol/match/match.schema";
import { responseMatchByMatchId } from "./response";

@Injectable()
export class MatchService {
  constructor(@InjectModel(Match.name) private matchModel: Model<Match>) {}

  async getMatches(puuid: string, limit: number): Promise<MatchDto[]> {
    return await this.matchModel
      .find({ "info.participants.puuid": puuid }, null, { limit: limit })
      .sort({ "info.gameCreation": -1 });
  }
}
