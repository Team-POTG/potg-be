import { Module } from "@nestjs/common";
import { LOLService } from "./lol.service";
import { LOLController } from "./lol.controller";
import { MatchModule } from "./api/match/match.module";
import { SummonerModule } from "./api/summoner/summoner.module";
import { RequestModule } from "./api/request/request.module";
import { LeagueModule } from "./api/league/league.module";
import { AccountModule } from "../common/api/account/account.module";

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
