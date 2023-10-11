import { Module } from "@nestjs/common";
import { MongooseModule } from "@nestjs/mongoose";
import { MongoService } from "./mongo.service";
import { ConfigModule } from "@nestjs/config";
import { MongoController } from "./mongo.controller";
import { Summoner, SummonerSchema } from "./schemas/summoner.schema";

@Module({
  imports: [
    ConfigModule.forRoot(),
    MongooseModule.forRoot(process.env.DATABASE_URI),
    MongooseModule.forFeature([
      { name: Summoner.name, schema: SummonerSchema },
    ]),
  ],
  controllers: [MongoController],
  providers: [MongoService],
})
export class MongoModule {}
