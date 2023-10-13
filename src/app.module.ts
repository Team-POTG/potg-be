import { Module } from "@nestjs/common";
import { AppController } from "./app.controller";
import { AppService } from "./app.service";
import { LOLModule } from "./riot/games/lol/lol.module";
import { MongooseModule } from "@nestjs/mongoose";
import { ConfigModule } from "@nestjs/config";

@Module({
  //TODO: 'potg-[game]-[region]'으로 db 나누기
  imports: [
    ConfigModule.forRoot(),
    MongooseModule.forRoot(process.env.DATABASE_URI),
    LOLModule,
  ],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
