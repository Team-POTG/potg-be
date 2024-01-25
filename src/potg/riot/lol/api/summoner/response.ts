/**
 * Summoner-V4
 */
import { RegionOfCountry } from "src/potg/riot/common/types/regions";
import { SummonerDto } from "./dto/summoner.dto";

/**
 * 지역과 puuid로 Riot SummonerAPI 호출
 * @param puuid 암호화된 puuid
 * @param region 지역(국가)
 * @returns SummonerDto
 */
export async function responseSummonerApiByPuuid(
  puuid: string,
  region: RegionOfCountry
): Promise<SummonerDto> {
  return await fetch(
    `https://${region}.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/${puuid}?api_key=${process.env.RIOT_API_KEY}`
  ).then((data) => data.json());
}
