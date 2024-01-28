import { Module } from "@nestjs/common";
import { RequestController } from "./request.controller";
import { MongooseModule } from "@nestjs/mongoose";
import { Summoner, SummonerSchema } from "../summoner/schema/summoner.schema";
import { Match, MatchSchema } from "../match/schema/match.schema";
import { RequestService } from "./request.service";
import { Account } from "src/potg/riot/common/api/account/schema/account.schema";
import { AccountSchema } from "src/models/schema/riot/common/account.schema";

@Module({
  imports: [
    MongooseModule.forFeature([
      { name: Account.name, schema: AccountSchema },
      { name: Match.name, schema: MatchSchema },
      { name: Summoner.name, schema: SummonerSchema },
    ]),
  ],
  controllers: [RequestController],
  providers: [RequestService],
})
export class RequestModule {
  constructor(private requestService: RequestService) {}
}
