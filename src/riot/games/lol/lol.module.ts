import { Module } from "@nestjs/common";
import { LOLService } from "./lol.service";
import { LOLController } from "./lol.controller";
import { MongooseModule } from "@nestjs/mongoose";
import { Summoner, SummonerSchema } from "./api/schemas/summoner.schema";

@Module({
  imports: [
    MongooseModule.forFeature([
      { name: Summoner.name, schema: SummonerSchema },
    ]),
  ],
  controllers: [LOLController],
  providers: [LOLService],
})
export class LOLModule {
  constructor(private lolService: LOLService) {}
}
