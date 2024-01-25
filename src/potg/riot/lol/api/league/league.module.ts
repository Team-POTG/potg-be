import { Module } from "@nestjs/common";
import { MongooseModule } from "@nestjs/mongoose";
import { League, LeagueSchema } from "./schema/league.schema";
import { LeagueController } from "./league.controller";
import { LeagueService } from "./league.service";

@Module({
  imports: [
    MongooseModule.forFeature([{ name: League.name, schema: LeagueSchema }]),
  ],
  controllers: [LeagueController],
  providers: [LeagueService],
})
export class LeagueModule {
  constructor(private leagueModule: LeagueService) {}
}
