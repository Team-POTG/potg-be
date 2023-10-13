/**
 * Summoner-V4
 */
import { RegionOfCountry } from "src/riot/games/lol/api/types/regions";
import { SummonerDto } from "../dto/summoner.dto";

/**
 * 지역과 소환사명으로 SummonerAPI 반환
 * @param summonerName 소환사명
 * @param region 지역(국가)
 */
export async function responseSummonerApiBySummonerName(
  summonerName: string,
  region: RegionOfCountry
): Promise<SummonerDto> {
  //TODO : query에서 가져오기
  return await fetch(
    `https://${region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/${summonerName}?api_key=${process.env.RIOT_API_KEY}`
  ).then((data) => data.json());
}
