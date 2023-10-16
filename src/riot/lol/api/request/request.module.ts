import { Module } from "@nestjs/common";
import { RequestService } from "./RequestService";
import { RequestController } from "./request.controller";
import { MongooseModule } from "@nestjs/mongoose";
import { Summoner, SummonerSchema } from "../summoner/schemas/summoner.schema";
import { Match, MatchSchema } from "../match/schemas/match.schema";

@Module({
  imports: [
    MongooseModule.forFeature([
      { name: Summoner.name, schema: SummonerSchema },
      { name: Match.name, schema: MatchSchema },
    ]),
  ],
  controllers: [RequestController],
  providers: [RequestService],
})
export class RequestModule {
  constructor(private requestService: RequestService) {}
}
