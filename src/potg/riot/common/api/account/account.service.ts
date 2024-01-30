import { Model } from "mongoose";
import { Injectable, Inject } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { RegionOfContinent } from "../../types/regions";
import { Account, AccountSchema } from "./schema/account.schema";
import { RequestService } from "src/potg/riot/lol/api/request/request.service";
import { getCountryToContinent } from "src/potg/riot/lol/controller/regionRouting";
import { RegionOfCountry } from "src/types/regions";
import { AccountDto } from "src/models/dto/riot/common/account.dto";

@Injectable()
export class AccountService {
  constructor(
    @InjectModel(Account.name) private accountModel: Model<Account>
  ) {}
  async getAccountByGameNameWithTagLine(
    tagLine: string,
    gameName: string,
    region: RegionOfCountry
  ): Promise<AccountDto> {
    return await this.accountModel
      .findOne({
        tagLine: tagLine,
        gameName: gameName,
      })
      .collation({ locale: "ko", strength: 2, alternate: "shifted" })
      .then((account) => {
        if (account) return account.toJSON();
        else {
          new RequestService().requestByTagGameNameWithTagLine(
            tagLine,
            gameName,
            region
          );
        }
      });
  }
}
