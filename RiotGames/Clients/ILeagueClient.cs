using potg.RiotGames.Dto;
using potg.RiotGames.Dto.League;
using Refit;

namespace potg.RiotGames.Clients;

public interface ILeagueClient
{
    [Get("/lol/league/v4/entries/by-summoner/{encryptedSummonerId}")]
    Task<ApiResponse<IEnumerable<LeagueEntryDto>>> GetLeagueEntry(string encryptedSummonerId, [Header("X-Riot-Token")] string key);
}
