import { Injectable } from "@nestjs/common";
import { RegionOfCountry } from "src/potg/riot/common/types/regions";
import { responseSpectatorBySummonerId } from "./response";
import { CurrentGameInfo } from "src/models/dto/riot/lol/spectator/currentGameInfo.dto";

export class SpectatorService {
  constructor(private spectatorService: SpectatorService) {}

  async getSpectator(
    summonerId: string,
    region: RegionOfCountry
  ): Promise<CurrentGameInfo> {
    return await responseSpectatorBySummonerId(summonerId, region);
  }
}
