import { Module } from "@nestjs/common";
import { MongooseModule } from "@nestjs/mongoose";
import { LeagueController } from "./league.controller";
import { LeagueService } from "./league.service";
import {
  League,
  LeagueSchema,
} from "src/models/schema/riot/lol/league/league.schema";

@Module({
  imports: [
    MongooseModule.forFeature([{ name: League.name, schema: LeagueSchema }]),
  ],
  controllers: [LeagueController],
  providers: [LeagueService],
  exports: [LeagueService],
})
export class LeagueModule {
  constructor(private leagueModule: LeagueService) {}
}
