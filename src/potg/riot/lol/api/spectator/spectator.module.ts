import { Module } from "@nestjs/common";
import { SpectatorController } from "./spectator.controller";
import { SpectatorService } from "./spectator.service";
import { AccountModule } from "src/potg/riot/common/api/account/account.module";
import { SummonerModule } from "../summoner/summoner.module";
import { MongooseModule } from "@nestjs/mongoose/dist/mongoose.module";
import {
  Account,
  AccountSchema,
} from "src/models/schema/riot/common/account.schema";
import { LeagueModule } from "../league/league.module";
import { MatchModule } from "../match/match.module";

@Module({
  imports: [AccountModule, LeagueModule, MatchModule],
  controllers: [SpectatorController],
  providers: [SpectatorService],
})
export class SpectatorModule {
  constructor(private spectatorService: SpectatorService) {}
}
