import { log } from "console";
import { RegionOfContinent } from "../../types/regions";
import { AccountDto } from "src/models/dto/riot/common/account.dto";

export async function responseAccountByGameNameWithTagLine(
  tagLine: string,
  gameName: string,
  region: RegionOfContinent
): Promise<AccountDto> {
  return await fetch(
    `https://${region}.api.riotgames.com/riot/account/v1/accounts/by-riot-id/${gameName}/${tagLine}?api_key=${process.env.RIOT_API_KEY}`
  ).then((data) => data.json());
}

export async function responseAccountByPuuid(
  puuid: string,
  region: RegionOfContinent
): Promise<AccountDto> {
  return await fetch(
    `https://${region}.api.riotgames.com/riot/account/v1/accounts/by-puuid/${puuid}?api_key=${process.env.RIOT_API_KEY}`
  ).then((data) => data.json());
}
