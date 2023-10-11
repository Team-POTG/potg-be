/**
 * Summoner-V4
 */
import { RegionOfCountry } from 'src/riot/types/regions';
import { SummonerDTO } from './dto/SummonerDTO';

/**
 * 지역과 소환사명으로 SummonerAPI 반환
 * @param summonerName 소환사명
 * @param region 지역(국가)
 */
export async function getSummonerByName(
  summonerName: string,
  region: RegionOfCountry,
): Promise<SummonerDTO> {
  console.log(
    `https://${region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/${summonerName}?api_key=${process.env.RIOT_API_KEY}`,
  );
  return await fetch(
    `https://${region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/${summonerName}?api_key=${process.env.RIOT_API_KEY}`,
  ).then((data) => data.json());
}
