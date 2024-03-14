import { Model } from "mongoose";
import { Injectable, Inject } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { RegionOfContinent } from "../../types/regions";
import { Account, AccountSchema } from "./schema/account.schema";
import { RequestService } from "src/potg/riot/lol/api/request/request.service";
import { getCountryToContinent } from "src/potg/riot/lol/controller/regionRouting";
import { RegionOfCountry } from "src/types/regions";
import { AccountDto } from "src/models/dto/riot/common/account.dto";
import { responseAccountByPuuid } from "./response";

@Injectable()
export class AccountService {
  constructor(
    @InjectModel(Account.name) private accountModel: Model<Account>,
    private requestService: RequestService
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
          this.requestService.requestByGameNameWithTagLine(
            tagLine,
            gameName,
            region
          );
        }
      });
  }

  async getAccountByPuuid(
    puuid: string,
    region: RegionOfCountry
  ): Promise<AccountDto> {
    return await this.accountModel
      .findOne({ puuid: puuid })
      .then(async (account) => {
        if (account) return account;
        else
          return this.accountModel
            .create(
              await responseAccountByPuuid(puuid, getCountryToContinent(region))
            )
            .then((createdAccount) => createdAccount);
      });
  }

  async updateAccounByPuuid(
    puuid: string,
    region: RegionOfCountry
  ): Promise<AccountDto> {
    return await this.accountModel
      .findOneAndUpdate(
        { puuid: puuid },
        await responseAccountByPuuid(puuid, getCountryToContinent(region))
      )
      .then((account) => account);
  }
}
