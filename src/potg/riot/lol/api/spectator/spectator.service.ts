import { Injectable } from "@nestjs/common";
import { RegionOfCountry } from "src/potg/riot/common/types/regions";
import { responseSpectatorByPuuid } from "./response";
import { CurrentGameInfo } from "src/models/dto/riot/lol/spectator/currentGameInfo.dto";
import { InjectModel } from "@nestjs/mongoose";
import { Account } from "src/models/schema/riot/common/account.schema";
import { Model } from "mongoose";
import { AccountService } from "src/potg/riot/common/api/account/account.service";
import { SummonerService } from "../summoner/summoner.service";
import { LeagueService } from "../league/league.service";
import { MatchService } from "../match/match.service";

@Injectable()
export class SpectatorService {
  constructor(
    private accountService: AccountService,
    private leagueService: LeagueService,
    private matchService: MatchService
  ) {}

  async getSpectator(
    puuid: string,
    region: RegionOfCountry
  ): Promise<CurrentGameInfo> {
    const fetch = await responseSpectatorByPuuid(puuid, region);

    return {
      gameId: fetch.gameId,
      gameType: fetch.gameType,
      gameStartTime: fetch.gameStartTime,
      mapId: fetch.mapId,
      gameLength: fetch.gameLength ?? 0,
      platformId: fetch.platformId,
      gameMode: fetch.gameMode,
      bannedChampions: [{ pickTurn: 0, championId: 0, teamId: 0 }],
      gameQueueConfigId: 0,
      participants: await Promise.all(
        fetch.participants.map(async (participant) => {
          const account = await this.accountService.getAccountByPuuid(
            participant.puuid,
            region
          );

          return {
            championId: participant.championId,
            perks: participant.perks,
            profileIconId: participant.profileIconId,
            bot: participant.bot,
            teamId: participant.teamId,
            account: {
              tagLine: account.tagLine,
              gameName: account.gameName,
            },
            summonerId: participant.summonerId,
            puuid: participant.puuid,
            spell1Id: participant.spell1Id,
            spell2Id: participant.spell2Id,
            gameCustomizationObjects: participant.gameCustomizationObjects,
            leagues: await this.leagueService.getLeaguesBySummonerId(
              participant.summonerId,
              region
            ),
            // TODO: 랭크, 일반, 칼바람나락 각 매치에 맞게 구분해서 전송
            recentMatches: await this.matchService
              .getMatches(participant.puuid, 5)
              .then((match) =>
                match.map((matchData) => {
                  const matchInfo = matchData.info.participants
                    .filter(
                      (participantData) =>
                        participantData.puuid === participant.puuid
                    )
                    .at(0);

                  return {
                    date: matchData.info.gameCreation,
                    championId: matchInfo.championId,
                    championName: matchInfo.championName,
                    kills: matchInfo.kills,
                    deaths: matchInfo.deaths,
                    assists: matchInfo.assists,
                    isWin: matchInfo.win,
                  };
                })
              ),
          };
        })
      ),
      observers: { encryptionKey: fetch.observers.encryptionKey },
    };
  }
}
