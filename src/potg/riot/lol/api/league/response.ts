/**
 * Match-V5
 */
import { log } from "console";
import { LeagueEntryDto } from "src/models/dto/riot/lol/league/leagueEntry.dto";
import {
  RegionOfContinent,
  RegionOfCountry,
} from "src/potg/riot/common/types/regions";

/**
 * LeagueAPI 반환
 * @param puuid 고유한 소환사의 id
 * @param region 국가(대륙)
 * @param startTime Epoch 시간, 2021년 6월 16일 이전의 데이터는 반환하지 않음
 * @param endTime
 * @param queue
 * @param type 게임 모드 구분
 * @param start start index
 * @param count start index에서 n개
 * @returns
 */
export async function responseLeagueBySummonerId(
  summonerId: string,
  region: RegionOfCountry
): Promise<LeagueEntryDto[]> {
  return await fetch(
    `https://${region}.api.riotgames.com/lol/league/v4/entries/by-summoner/${summonerId}?api_key=${process.env.RIOT_API_KEY}`
  ).then((data) => data.json());
}

// export async function responseMatchByMatchId(
//   matchId: string,
//   region: RegionOfContinent
// ): Promise<MatchDto> {
//   return await fetch(
//     `https://${region}.api.riotgames.com/lol/match/v5/matches/${matchId}?api_key=${process.env.RIOT_API_KEY}`
//   ).then((data) => data.json());
// }
