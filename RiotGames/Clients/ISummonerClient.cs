using potg.RiotGames.Dto;
using potg.RiotGames.Dto.Summoner;
using Refit;

namespace potg.RiotGames.Clients;

public interface ISummonerClient
{

    [Get("/lol/summoner/v4/summoners/by-name/{summonerName}")]
    Task<ApiResponse<SummonerDto>> GetSummonerByName(string summonerName, [Header("X-Riot-Token")] string key);
}