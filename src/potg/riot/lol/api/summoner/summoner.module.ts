import { Module } from "@nestjs/common";
import { MongooseModule } from "@nestjs/mongoose";
import { Summoner, SummonerSchema } from "./schema/summoner.schema";
import { SummonerController } from "./summoner.controller";
import { SummonerService } from "./summoner.service";

@Module({
  imports: [
    MongooseModule.forFeature([
      { name: Summoner.name, schema: SummonerSchema },
    ]),
  ],
  controllers: [SummonerController],
  providers: [SummonerService],
  exports: [SummonerService],
})
export class SummonerModule {
  constructor(private summonerService: SummonerService) {}
}
