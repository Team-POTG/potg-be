import { Module } from "@nestjs/common";
import { AppController } from "./app.controller";
import { AppService } from "./app.service";
// import { LOLModule } from "./potg/riot/lol/lol.module";
import { MongooseModule } from "@nestjs/mongoose";
import { ConfigModule } from "@nestjs/config";
import { GraphQLModule } from "@nestjs/graphql";
import { ApolloDriver, ApolloDriverConfig } from "@nestjs/apollo";
import { LOLModule } from "./potg/riot/lol/lol.module";

@Module({
  imports: [
    ConfigModule.forRoot(),
    MongooseModule.forRoot(process.env.DATABASE_URI),
    LOLModule,
  ],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
