import { Injectable } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { MatchDto } from "src/models/dto/riot/lol/match/match.dto";
import { Match } from "src/models/schema/riot/lol/match/match.schema";

@Injectable()
export class MatchService {
  constructor(@InjectModel(Match.name) private matchModel: Model<Match>) {}

  async getMatch(puuid: string, count: number): Promise<MatchDto[]> {
    return await this.matchModel
      .find({ "info.participants.puuid": puuid }, null, { limit: count })
      .sort({ _id: -1 })
      .exec();
  }
}
