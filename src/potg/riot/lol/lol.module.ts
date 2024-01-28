import { Module } from "@nestjs/common";
import { LOLService } from "./lol.service";
import { LOLController } from "./lol.controller";
import { MatchModule } from "./api/match/match.module";
import { SummonerModule } from "./api/summoner/summoner.module";
import { RequestModule } from "./api/request/request.module";
import { LeagueModule } from "./api/league/league.module";
import { AccountModule } from "../common/api/account/account.module";
import { MongooseModule } from "@nestjs/mongoose";
import {
  Account,
  AccountSchema,
} from "../common/api/account/schema/account.schema";
import { Match, MatchSchema } from "./api/match/schema/match.schema";
import {
  Summoner,
  SummonerSchema,
} from "./api/summoner/schema/summoner.schema";
import { RequestController } from "./api/request/request.controller";
import { RequestService } from "./api/request/request.service";

@Module({
  imports: [
    AccountModule,
    SummonerModule,
    MatchModule,
    RequestModule,
    LeagueModule,
  ],
  controllers: [LOLController],
  providers: [LOLService],
})
export class LOLModule {
  constructor(private lolService: LOLService) {}
}
