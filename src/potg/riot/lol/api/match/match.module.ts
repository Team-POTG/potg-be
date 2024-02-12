import { Module } from "@nestjs/common";
import { MatchController } from "./match.controller";
import { MatchService } from "./match.service";
import { MatchResolver } from "./match.resolver";
import { ApolloDriverConfig, ApolloDriver } from "@nestjs/apollo";
import { GraphQLModule } from "@nestjs/graphql";
import { MongooseModule } from "@nestjs/mongoose";
import {
  Match,
  MatchSchema,
} from "src/models/schema/riot/lol/match/match.schema";

@Module({
  imports: [
    GraphQLModule.forRoot<ApolloDriverConfig>({
      driver: ApolloDriver,
      autoSchemaFile: "./schema/match.gql",
      playground: false,
    }),
    MongooseModule.forFeature([{ name: Match.name, schema: MatchSchema }]),
  ],
  controllers: [MatchController],
  providers: [MatchService, MatchResolver],
})
export class MatchModule {
  constructor(private matchService: MatchService) {}
}
