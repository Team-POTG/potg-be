import { CurrentGameInfo } from "src/models/dto/riot/lol/spectator/currentGameInfo.dto";
import { RegionOfCountry } from "src/types/regions";

export async function responseSpectatorBySummonerId(
  summonerId: string,
  region: RegionOfCountry
): Promise<CurrentGameInfo> {
  return await fetch(
    `https://${region}.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/${summonerId}?api_key=${process.env.RIOT_API_KEY}`
  ).then((data) => data.json());
}
