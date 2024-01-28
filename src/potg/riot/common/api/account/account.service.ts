import { Model } from "mongoose";
import { Injectable, Inject } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { RegionOfContinent } from "../../types/regions";
import { Account, AccountSchema } from "./schema/account.schema";
import { RequestService } from "src/potg/riot/lol/api/request/request.service";
import { getCountryToContinent } from "src/potg/riot/lol/controller/regionRouting";
import { RegionOfCountry } from "src/types/regions";

@Injectable()
export class AccountService {
  constructor(
    @InjectModel(Account.name) private accountModel: Model<Account>
  ) {}
  async getAccountByGameNameWithTagLine(
    tagLine: string,
    gameName: string,
    region: RegionOfCountry
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
          new RequestService().requestByTagLineWithGameName(
            tagLine,
            gameName,
            region
          );
        }
      });
  }
}
