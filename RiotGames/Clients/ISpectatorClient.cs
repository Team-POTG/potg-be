using potg.RiotGames.Dto;
using potg.RiotGames.Dto.League;
using potg.RiotGames.Dto.Spectator;
using Refit;

namespace potg.RiotGames.Clients;

public interface ISpectatorClient
{
    [Get("/lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId}")]
    Task<ApiResponse<CurrentGameInfo>> GetCurrentGame(string encryptedSummonerId, [Header("X-Riot-Token")] string key);
}
