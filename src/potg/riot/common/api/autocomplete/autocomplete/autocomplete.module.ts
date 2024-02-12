import { Module } from "@nestjs/common";
import { AutocompleteController } from "./autocomplete.controller";
import { AutocompleteService } from "./autocomplete.service";
import { MongooseModule } from "@nestjs/mongoose";
import { Account, AccountSchema } from "../../account/schema/account.schema";
import { AccountModule } from "../../account/account.module";

@Module({
  imports: [
    MongooseModule.forFeature([{ name: Account.name, schema: AccountSchema }]),
  ],
  controllers: [AutocompleteController],
  providers: [AutocompleteService],
})
export class AutocompleteModule {}
