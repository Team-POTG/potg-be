using ComposableAsync;
using Microsoft.Extensions.Options;
using potg.RiotGames.Clients;
using potg.RiotGames.Dto.League;
using RateLimiter;
using Refit;

namespace potg.RiotGames.Services;

public class LeagueService
{
    private readonly string _apiKey;
    private readonly RefitSettings _settings = new(new NewtonsoftJsonContentSerializer());
    private readonly TimeLimiter _timeConstraint = TimeLimiter.GetFromMaxCountByInterval(60, TimeSpan.FromMinutes(1));

    public LeagueService(IOptions<RiotApiConfiguration> options) => _apiKey = options.Value.ApiKey;

    public async Task<ApiResponse<IEnumerable<LeagueEntryDto>>> GetLeagueEntries(string encryptedSummonerId, string region)
    {
        await _timeConstraint;

        var leagueClient = RestService.For<ILeagueClient>($"https://{region}.api.riotgames.com", _settings);
        var response = await leagueClient.GetLeagueEntry(encryptedSummonerId, _apiKey);
        return response;
    }
}