import { Injectable } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { MatchDto } from "./dto/match.dto";
import { Match } from "./schema/match.schema";

@Injectable()
export class MatchService {
  constructor(@InjectModel(Match.name) private matchModel: Model<Match>) {}

  async getMatch(puuid: string, count: number): Promise<MatchDto[]> {
    return await this.matchModel
      .find({ "info.participants.puuid": puuid }, null, { limit: count })
      .exec();
  }
}
