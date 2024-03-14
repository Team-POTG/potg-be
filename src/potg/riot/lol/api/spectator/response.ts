import { CurrentGameInfo } from "src/models/dto/riot/lol/spectator/currentGameInfo.dto";
import { RegionOfCountry } from "src/types/regions";

export async function responseSpectatorByPuuid(
  puuid: string,
  region: RegionOfCountry
): Promise<CurrentGameInfo> {
  return await fetch(
    `https://${region}.api.riotgames.com/lol/spectator/v5/active-games/by-summoner/${puuid}?api_key=${process.env.RIOT_API_KEY}`
  ).then((data) => data.json());
}
