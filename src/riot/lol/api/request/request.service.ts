import { Injectable } from "@nestjs/common";
import { RegionOfCountry } from "src/riot/lol/types/regions";
import { InjectModel } from "@nestjs/mongoose";
import { Model } from "mongoose";
import {
  responseSummonerApiByPuuid,
  responseSummonerApiBySummonerName,
} from "../summoner/response";
import { Summoner } from "../summoner/schemas/summoner.schema";
import { Match } from "../match/schemas/match.schema";
import {
  responseMatchByMatchId,
  responseMatchListByPuuid,
} from "../match/response";
import { getCountryToContinent } from "../../controller/regionRouting";
import { MatchDto } from "../match/dto/match.dto";
import { SummonerDto } from "../summoner/dto/summoner.dto";

@Injectable()
export class RequestService {
  constructor(
    // TODO: request,match 나눴더니 의존 오류남
    @InjectModel(Summoner.name) private summonerModel: Model<Summoner>,
    @InjectModel(Match.name) private matchModel: Model<Match>
  ) {}

  async requestBySummonerName(summonerName: string, region: RegionOfCountry) {
    const summonerData = await responseSummonerApiBySummonerName(
      summonerName,
      region
    );

    const matchesData = await responseMatchListByPuuid(
      summonerData.puuid,
      getCountryToContinent(region)
    );

    // TODO: 분리하여 재활용하기
    // summonerData의 puuid가 db에 존재하지 않으면 생성, 존재하면 업데이트
    await this.summonerModel
      .findOneAndUpdate({ puuid: summonerData.puuid }, summonerData)
      .then(async (summoner) => {
        if (!summoner)
          await this.summonerModel.create<SummonerDto>(summonerData);
      });

    matchesData.forEach(async (matchId) => {
      return await responseMatchByMatchId(
        matchId,
        getCountryToContinent(region)
      ).then(async (match) => {
        await this.matchModel
          .findOne({
            // matchId와 puuid를 대조하여 매치 검색
            "metadata.matchId": matchId,
          })
          .then(async (foundMatch) => {
            // find에서 문서를 찾지 못했다면 match 문서 추가
            //FIXME: request 두 번 하면 더미데이터 생성됨.
            if (!foundMatch) {
              await this.matchModel.create<MatchDto>(match);
            }
          });
      });
    });
  }

  async requestByPuuid(puuid: string, region: RegionOfCountry) {
    const summonerData = await responseSummonerApiByPuuid(puuid, region);

    // summonerData의 puuid가 db에 존재하지 않으면 생성, 존재하면 업데이트
    await this.summonerModel
      .exists({ puuid: summonerData.puuid })
      .then(async () => {
        await this.summonerModel.findOneAndUpdate(
          { puuid: summonerData.puuid },
          summonerData
        );
      })
      .catch(async () => {
        await this.summonerModel.create(summonerData);
      });
  }
}
