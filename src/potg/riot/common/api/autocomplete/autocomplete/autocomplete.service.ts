import { Injectable } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { Account } from "../../account/schema/account.schema";
import { Model } from "mongoose";

@Injectable()
export class AutocompleteService {
  constructor(
    @InjectModel(Account.name) private accountModel: Model<Account>
  ) {}

  async getAutocompleteByRiotId(tagLine: string, gameName: string) {
    // const _riotId = {
    //   gameName: riotId.split("#")[0],
    //   tagLine: riotId.split("#")[1],
    // };
    // return { tagLine: tagLine, gameName: gameName };
    console.log(tagLine, gameName);
    return await this.accountModel
      .find({
        tagLine: { $regex: `^${tagLine ?? ""}`, $options: "i" },
        gameName: { $regex: `^${gameName}`, $options: "i" },
      })
      .collation({ locale: "ko", strength: 2, alternate: "shifted" })
      .then((account) => {
        return account;
      });
  }
}
