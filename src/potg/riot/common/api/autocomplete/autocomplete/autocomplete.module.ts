import { Module } from "@nestjs/common";
import { AutocompleteController } from "./autocomplete.controller";
import { AutocompleteService } from "./autocomplete.service";
import { MongooseModule } from "@nestjs/mongoose";
import { Account, AccountSchema } from "../../account/schema/account.schema";
import { AccountModule } from "../../account/account.module";
import {
  Summoner,
  SummonerSchema,
} from "src/models/schema/riot/lol/summoner/summoner.schema";
import { SummonerService } from "src/potg/riot/lol/api/summoner/summoner.service";
import { SummonerModule } from "src/potg/riot/lol/api/summoner/summoner.module";
import { LeagueModule } from "src/potg/riot/lol/api/league/league.module";
import {
  League,
  LeagueSchema,
} from "src/models/schema/riot/lol/league/league.schema";

@Module({
  imports: [
    MongooseModule.forFeature([
      { name: Summoner.name, schema: SummonerSchema },
      { name: Account.name, schema: AccountSchema },
      { name: League.name, schema: LeagueSchema },
    ]),
  ],
  controllers: [AutocompleteController],
  providers: [AutocompleteService],
})
export class AutocompleteModule {}
