import { Module } from "@nestjs/common";
import { AccountController } from "./account.controller";
import { AccountService } from "./account.service";
import { MongooseModule } from "@nestjs/mongoose";
import { Account, AccountSchema } from "./schema/account.schema";
import { RequestModule } from "src/potg/riot/lol/api/request/request.module";
import { RequestService } from "src/potg/riot/lol/api/request/request.service";

@Module({
  imports: [
    MongooseModule.forFeature([{ name: Account.name, schema: AccountSchema }]),
    RequestModule,
    AccountModule,
  ],
  controllers: [AccountController],
  providers: [AccountService],
})
export class AccountModule {
  constructor(private accountModule: AccountService) {}
}
