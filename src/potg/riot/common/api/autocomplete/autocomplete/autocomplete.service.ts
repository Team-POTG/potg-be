import { Injectable } from "@nestjs/common";
import { InjectModel } from "@nestjs/mongoose";
import { Account } from "../../account/schema/account.schema";
import { Model } from "mongoose";
import { Summoner } from "src/models/schema/riot/lol/summoner/summoner.schema";
import { League } from "src/models/schema/riot/lol/league/league.schema";
import { AutocompleteDto } from "src/models/dto/riot/common/autocomplete.dto";

@Injectable()
export class AutocompleteService {
  constructor(
    @InjectModel(Account.name) private accountModel: Model<Account>,
    @InjectModel(Summoner.name) private summonerModel: Model<Summoner>,
    @InjectModel(League.name) private leagueModel: Model<League>
  ) {}

  async getAutocompleteByRiotId(
    tagLine: string,
    gameName: string,
    limit: number
  ): Promise<AutocompleteDto[]> {
    if (gameName) {
      const accounts = await this.accountModel
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
        .limit(limit)
        .exec()
        .then((account) => account);

      const summoners = await this.summonerModel.find({
        puuid: { $in: accounts.map((account) => account.puuid) },
      });

      const leagues = await this.leagueModel
        .find({
          "info.summonerId": { $in: summoners.map((summoner) => summoner.id) },
        })
        .then((leagues) => leagues ?? []);

      // TODO: league에 정보가 존재하지 않으면 tier, rank는 보내지 않기
      return accounts.map((account) => {
        const summoner = summoners.filter(
          (summoner) => summoner.puuid === account.puuid
        )[0];
        const league = leagues
          .filter(
            (league) =>
              league.info[0].summonerId ===
              summoners.filter(
                (summoner) => summoner.puuid === account.puuid
              )[0].id
          )[0]
          .info.filter(
            (queueType) => queueType.queueType === "RANKED_SOLO_5x5"
          )[0];

        return {
          gameName: account.gameName,
          tagLine: account.tagLine,
          profileIconId: summoner.profileIconId,
          summonerLevel: summoner.summonerLevel,
          tier: league.tier ?? "",
          rank: league.rank ?? "",
          leaguePoint: league.leaguePoints,
        };
      });
    }
  }
}
