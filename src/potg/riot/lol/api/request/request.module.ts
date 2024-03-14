import { Module } from "@nestjs/common";
import { RequestController } from "./request.controller";
import { MongooseModule } from "@nestjs/mongoose";
import { Summoner, SummonerSchema } from "../summoner/schema/summoner.schema";
import { RequestService } from "./request.service";
import { Account } from "src/potg/riot/common/api/account/schema/account.schema";
import { AccountSchema } from "src/models/schema/riot/common/account.schema";
import {
  Match,
  MatchSchema,
} from "src/models/schema/riot/lol/match/match.schema";
import {
  League,
  LeagueSchema,
} from "src/models/schema/riot/lol/league/league.schema";
import { LeagueService } from "../league/league.service";
import { LeagueModule } from "../league/league.module";
import { MatchModule } from "../match/match.module";

@Module({
  imports: [
    MongooseModule.forFeature([
      { name: Account.name, schema: AccountSchema },
      { name: Match.name, schema: MatchSchema },
      { name: Summoner.name, schema: SummonerSchema },
      { name: League.name, schema: LeagueSchema },
    ]),
    LeagueModule,
  ],
  controllers: [RequestController],
  providers: [RequestService],
  exports: [RequestService],
})
export class RequestModule {
  constructor(private requestService: RequestService) {}
}
