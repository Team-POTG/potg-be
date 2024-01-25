import { Module } from "@nestjs/common";
import { AccountController } from "./account.controller";
import { AccountService } from "./account.service";
import { MongooseModule } from "@nestjs/mongoose";
import { Account, AccountSchema } from "./schema/account.schema";

@Module({
  imports: [
    MongooseModule.forFeature([{ name: Account.name, schema: AccountSchema }]),
    AccountModule,
  ],
  controllers: [AccountController],
  providers: [AccountService],
})
export class AccountModule {
  constructor(private accountModule: AccountService) {}
}
