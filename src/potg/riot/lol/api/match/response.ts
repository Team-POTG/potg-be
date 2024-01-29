/**
 * Match-V5
 */
import { RegionOfContinent } from "src/potg/riot/common/types/regions";
import { MatchDto } from "./dto/match.dto";
import axios from "axios";
import { log } from "console";

/**
 * MatchAPI 반환
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
export async function responseMatchListByPuuid(
  puuid: string,
  region: RegionOfContinent,
  startTime?: number,
  endTime?: number,
  queue?: number,
  type?: "" | "ranked" | "normal" | "tourney" | "tutorial",
  start?: number,
  count?: number
): Promise<string[]> {
  const _startTime = startTime === undefined ? "" : `startTime=${startTime}&`;
  const _endTime = endTime === undefined ? "" : `endTime=${endTime}&`;
  const _queue = queue === undefined ? "" : `queue=${queue}&`;
  const _type = type === undefined ? "" : `type=${type}&`;

  return await fetch(
    `https://${region}.api.riotgames.com/lol/match/v5/matches/by-puuid/${puuid}/ids?${_startTime}${_endTime}${_queue}${_type}start=${
      start ?? "0"
    }&count=${count ?? "20"}&api_key=${process.env.RIOT_API_KEY}`
  ).then((data) => data.json());
  // return await axios
  //   .get(
  //     `https://${region}.api.riotgames.com/lol/match/v5/matches/by-puuid/${puuid}/ids?${_startTime}${_endTime}${_queue}${_type}start=${
  //       start ?? "0"
  //     }&count=${count ?? "20"}&api_key=${process.env.RIOT_API_KEY}`
  //   )
  //   .then((data) => data.data);

  // return await fetch(
  //   `https://${region}.api.riotgames.com/lol/match/v5/matches/by-puuid/${puuid}/ids?${_startTime}${_endTime}${_queue}${_type}start=${
  //     start ?? "0"
  //   }&count=${count ?? "20"}&api_key=${process.env.RIOT_API_KEY}`
  // ).then((data) => data.json());
}

export async function responseMatchByMatchId(
  matchId: string,
  region: RegionOfContinent
): Promise<MatchDto> {
  return await fetch(
    `https://${region}.api.riotgames.com/lol/match/v5/matches/${matchId}?api_key=${process.env.RIOT_API_KEY}`
  ).then((data) => data.json());
}
