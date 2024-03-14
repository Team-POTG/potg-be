import { Injectable } from "@nestjs/common";
import { RegionOfCountry } from "src/potg/riot/common/types/regions";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import { Summoner } from "../summoner/schema/summoner.schema";
import { Account } from "src/potg/riot/common/api/account/schema/account.schema";
import { responseSummonerByPuuid } from "../summoner/response";
import { getCountryToContinent } from "../../controller/regionRouting";
import { responseAccountByGameNameWithTagLine } from "src/potg/riot/common/api/account/response";
import {
  responseMatchByMatchId,
  responseMatchListByPuuid,
} from "../match/response";
import { Match } from "src/models/schema/riot/lol/match/match.schema";
import { LeagueService } from "../league/league.service";
import { League } from "src/models/schema/riot/lol/league/league.schema";

@Injectable()
export class RequestService {
  constructor(
    @InjectModel(Account.name) private accountModel: Model<Account>,
    @InjectModel(Match.name) private matchModel: Model<Match>,
    @InjectModel(Summoner.name) private summonerModel: Model<Summoner>,
    @InjectModel(League.name) private leagueModel: Model<League>,

    private leagueService: LeagueService
  ) {}

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

  async requestByGameNameWithTagLine(
    tagLine: string,
    gameName: string,
    region: RegionOfCountry
  ) {
    const accountData = await responseAccountByGameNameWithTagLine(
      tagLine,
      gameName,
      getCountryToContinent(region)
    );

    const summonerData = await responseSummonerByPuuid(
      accountData.puuid,
      region
    );

    const matchData = await responseMatchListByPuuid(
      accountData.puuid,
      getCountryToContinent(region),
      undefined,
      undefined,
      undefined,
      "",
      0,
      5
    );

    // Account
    await this.accountModel
      .findOne({ puuid: accountData.puuid })
      .then(async (account) => {
        if (account)
          // accountData의 puuid가 db에 존재하지 않으면 생성, 존재하면 업데이트
          await this.accountModel
            .findOne({ puuid: accountData.puuid })
            .updateOne(accountData);
        // response db 저장
        else await this.accountModel.create(accountData);
      });

    // Summoner
    await this.summonerModel
      .findOne({ puuid: summonerData.puuid })
      .then(async (summoner) => {
        if (summoner)
          await this.summonerModel
            .findOne({ puuid: summonerData.puuid })
            .updateOne(summonerData);
        else await this.summonerModel.create(summonerData);
      });

    // League
    this.leagueModel
      .findOne({ "info.summonerId": summonerData.id })
      .then(async (league) => {
        if (league) {
          await this.leagueService.updateLeaguesBySummonerId(
            summonerData.id,
            region
          );
        } else {
          await this.leagueService.getLeaguesBySummonerId(
            summonerData.id,
            region
          );
        }
      });

    // Match
    matchData.forEach(async (matchId) => {
      this.matchModel
        .findOne({ "metadata.matchId": matchId })
        .collation({ locale: "ko", strength: 2, alternate: "shifted" })
        .then(async (matchDbData) => {
          if (!matchDbData)
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
