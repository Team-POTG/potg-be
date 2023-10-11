import { Module } from "@nestjs/common";
import { AppController } from "./app.controller";
import { AppService } from "./app.service";
import { ConfigModule } from "@nestjs/config";
import { LOLModule } from "./riot/games/lol/lol.module";
import { MongoModule } from "./database/mongo.module";
// import { MongooseModule } from '@nestjs/mongoose';

@Module({
  imports: [MongoModule, LOLModule],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
