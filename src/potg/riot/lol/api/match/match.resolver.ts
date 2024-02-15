import { Args, Query, Resolver } from "@nestjs/graphql";
import { MatchService } from "./match.service";
import { MatchDto } from "src/models/dto/riot/lol/match/match.dto";

@Resolver(() => MatchDto)
export class MatchResolver {
  constructor(private matchService: MatchService) {}

  @Query(() => [MatchDto])
  async getMatch(
    @Args("puuid") puuid: string,
    @Args("limit") limit: number
  ): Promise<MatchDto[]> {
    return await this.matchService.getMatch(puuid, limit);
  }
}
