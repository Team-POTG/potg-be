import { log } from "console";
import { RegionOfContinent } from "../../types/regions";
import { AccountDto } from "./dto/account.dto";
import { RegionOfCountry } from "src/types/regions";

export async function responseAccountByGameNameWithTagLine(
  tagLine: string,
  gameName: string,
  region: RegionOfContinent
): Promise<AccountDto> {
  console.log(
    `https://${region}.api.riotgames.com/riot/account/v1/accounts/by-riot-id/${gameName}/${tagLine}?api_key=${process.env.RIOT_API_KEY}`
  );
  return await fetch(
    `https://${region}.api.riotgames.com/riot/account/v1/accounts/by-riot-id/${gameName}/${tagLine}?api_key=${process.env.RIOT_API_KEY}`
  ).then((data) => data.json());
}
