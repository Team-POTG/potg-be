import { Module } from "@nestjs/common";
import { LOLService } from "./lol.service";
import { LOLController } from "./lol.controller";
import { MongooseModule } from "@nestjs/mongoose";
import {
  Summoner,
  SummonerSchema,
} from "./api/summoner/schemas/summoner.schema";
import { MatchResolver } from "./api/match/match.resolver";
import { SummonerService } from "./api/summoner/summoner.service";
import { SummonerController } from "./api/summoner/summoner.controller";
import { Match, MatchSchema } from "./api/match/schemas/match.schema";
import { MatchController } from "./api/match/match.controller";
import { MatchService } from "./api/match/match.service";
import { MatchModule } from "./api/match/match.module";
import { SummonerModule } from "./api/summoner/summoner.module";
import { RequestModule } from "./api/request/request.module";

@Module({
  imports: [SummonerModule, MatchModule, RequestModule],
  controllers: [LOLController],
  providers: [LOLService],
})
export class LOLModule {
  constructor(private lolService: LOLService) {}
}
