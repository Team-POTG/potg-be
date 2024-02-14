import { Injectable } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { Account } from "../../account/schema/account.schema";
import { Model } from "mongoose";
import { AccountDto } from "../../account/dto/account.dto";

@Injectable()
export class AutocompleteService {
  constructor(
    @InjectModel(Account.name) private accountModel: Model<Account>
  ) {}

  async getAutocompleteByRiotId(
    tagLine: string,
    gameName: string
  ): Promise<AccountDto[]> {
    // const _riotId = {
    //   gameName: riotId.split("#")[0],
    //   tagLine: riotId.split("#")[1],
    // };
    // return { tagLine: tagLine, gameName: gameName };
    console.log(tagLine, gameName);
    const test = gameName.replaceAll("", " ");
    console.log(test);
    if (gameName)
      return await this.accountModel
        .find({
          tagLine: {
            $regex: new RegExp(
              `^${tagLine === undefined ? "" : tagLine.split("").join("\\s*")}`
            ),
            $options: "i",
          },
          gameName: {
            $regex: new RegExp(`^${gameName.split("").join("\\s*")}`),
            $options: "i",
          },
        })
        .collation({
          locale: "ko",
          strength: 2,
          alternate: "shifted",
          normalization: true,
        })
        .exec()
        .then((account) => {
          return account;
        });
    else return [];
  }
}
