import { Model } from "mongoose";
import { Injectable, Inject } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { RegionOfContinent } from "../../types/regions";
import { Account, AccountSchema } from "./schema/account.schema";
import { responseAccountByTagLineWithGameName } from "./response";
import { RequestService } from "src/potg/riot/lol/api/request/request.service";

@Injectable()
export class AccountService {
  constructor(
    @InjectModel(Account.name) private accountModel: Model<Account>
  ) {}
  async getAccountByGameNameWithTagLine(
    tagLine: string,
    gameName: string,
    region: RegionOfContinent
  ) {
    return await this.accountModel
      .findOne({
        tagLine: tagLine,
        gameName: gameName,
      })
      .collation({ locale: "ko", strength: 2, alternate: "shifted" })
      .then((account) => {
        if (account) return account.toJSON();
        else {
          new RequestService(
            this.accountModel,
            null
          ).requestByTagLineWithGameName(tagLine, gameName, region);
        }
      });
  }
}
