import { Injectable } from "@nestjs/common";
import { RegionOfCountry } from "src/potg/riot/common/types/regions";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { responseSummonerApiByPuuid } from "../summoner/response";
import { Summoner } from "../summoner/schema/summoner.schema";
import { Match } from "../match/schema/match.schema";
import { RegionOfContinent } from "src/types/regions";
import { responseAccountByTagLineWithGameName } from "src/potg/riot/common/api/account/response";
import { Account } from "src/potg/riot/common/api/account/schema/account.schema";
import { AccountDto } from "src/models/dto/riot/common/account.dto";

@Injectable()
export class RequestService {
  constructor(
    // TODO: request,match 나눴더니 의존 오류남
    @InjectModel(Account.name) private accountModel: Model<Account>,
    @InjectModel(Match.name) private matchModel: Model<Match>
  ) {}

  async requestByPuuid(puuid: string, region: RegionOfCountry) {
    const summonerData = await responseSummonerApiByPuuid(puuid, region);

    // summonerData의 puuid가 db에 존재하지 않으면 생성, 존재하면 업데이트
    await this.accountModel
      .exists({ puuid: summonerData.puuid })
      .then(async () => {
        await this.accountModel.findOneAndUpdate(
          { puuid: summonerData.puuid },
          summonerData
        );
      })
      .catch(async () => {
        await this.accountModel.create(summonerData);
      });
  }

  async requestByTagLineWithGameName(
    tagLine: string,
    gameName: string,
    region: RegionOfContinent
  ) {
    const accountData = await responseAccountByTagLineWithGameName(
      tagLine,
      gameName,
      region
    );

    // const db = this.accountModel
    //   .exists({ puuid: accountData.puuid })
    //   .collation({ locale: "ko", strength: 2, alternate: "shifted" })
    //   .exec();

    // console.log(accountData);
    await this.accountModel
      .findOne({ puuid: accountData.puuid })
      // 대소문자를 구분하지 않고, 공백을 무시하며 검색
      .collation({ locale: "ko", strength: 2, alternate: "shifted" })
      .then(async (account) => {
        if (account)
          // accountData의 puuid가 db에 존재하지 않으면 생성, 존재하면 업데이트
          await this.accountModel
            .findOne({ puuid: accountData.puuid })
            .collation({ locale: "ko", strength: 2, alternate: "shifted" })
            .updateOne(accountData);
        else {
          // accountData db 저장
          await this.accountModel.create(accountData);
        }
      });
  }
}
