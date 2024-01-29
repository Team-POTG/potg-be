import { Injectable } from "@nestjs/common";
import { RegionOfCountry } from "src/potg/riot/common/types/regions";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { Summoner } from "../summoner/schema/summoner.schema";
import { Match } from "../match/schema/match.schema";
import { RegionOfContinent } from "src/types/regions";
import { Account } from "src/potg/riot/common/api/account/schema/account.schema";
import { AccountDto } from "src/models/dto/riot/common/account.dto";
import { responseSummonerByPuuid } from "../summoner/response";
import { getCountryToContinent } from "../../controller/regionRouting";
import { responseAccountByGameNameWithTagLine } from "src/potg/riot/common/api/account/response";
import {
  responseMatchByMatchId,
  responseMatchListByPuuid,
} from "../match/response";

@Injectable()
export class RequestService {
  @InjectModel(Account.name) private accountModel: Model<Account>;
  @InjectModel(Match.name) private matchModel: Model<Match>;
  @InjectModel(Summoner.name) private summonerModel: Model<Summoner>;
  constructor() {}

  async requestByPuuid(puuid: string, region: RegionOfCountry) {
    const summonerData = await responseSummonerByPuuid(puuid, region);

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

  async requestByTagGameNameWithTagLine(
    tagLine: string,
    gameName: string,
    region: RegionOfCountry
  ) {
    const accountData = await responseAccountByGameNameWithTagLine(
      tagLine,
      gameName,
      getCountryToContinent(region)
    );
    const response = {
      summoner: await responseSummonerByPuuid(accountData.puuid, region),
      match: await responseMatchListByPuuid(
        accountData.puuid,
        getCountryToContinent(region),
        undefined,
        undefined,
        undefined,
        "",
        0,
        5
      ),
    };

    // Account
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
          // response db 저장
          await this.accountModel.create(accountData);
        }
      });

    // Summoner
    await this.summonerModel
      .findOne({ puuid: response.summoner.puuid })
      .collation({ locale: "ko", strength: 2, alternate: "shifted" })
      .then(async (summoner) => {
        if (summoner)
          await this.summonerModel
            .findOne({ puuid: response.summoner.puuid })
            .collation({ locale: "ko", strength: 2, alternate: "shifted" })
            .updateOne(response.summoner);
        else await this.summonerModel.create(response.summoner);
      });

    // Match List
    response.match.forEach(async (matchId) => {
      this.matchModel
        .findOne({ "metadata.matchId": matchId })
        .collation({ locale: "ko", strength: 2, alternate: "shifted" })
        .then(async (matchDbData) => {
          if (matchDbData === null)
            await this.matchModel.create(
              await responseMatchByMatchId(
                matchId,
                getCountryToContinent(region)
              )
            );
        });
    });
  }
}
