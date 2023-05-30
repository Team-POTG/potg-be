using ComposableAsync;
using Microsoft.Extensions.Options;
using potg.RiotGames.Clients;
using potg.RiotGames.Dto.League;
using potg.RiotGames.Dto.Spectator;
using RateLimiter;
using Refit;

namespace potg.RiotGames.Services;

public class SpectatorService
{
    private readonly string _apiKey;
    private readonly RefitSettings _settings = new(new NewtonsoftJsonContentSerializer());
    private readonly TimeLimiter _timeConstraint;

    public SpectatorService(IOptions<RiotApiConfiguration> options)
    {
        _apiKey = options.Value.ApiKey;
        var constraint = new CountByIntervalAwaitableConstraint(20000, TimeSpan.FromSeconds(10));
        var constraint2 = new CountByIntervalAwaitableConstraint(1200000, TimeSpan.FromMinutes(10));
        _timeConstraint = TimeLimiter.Compose(constraint, constraint2);
    }

    public async Task<ApiResponse<CurrentGameInfo>> GetCurrentGame(string encryptedSummonerId, string region)
    {
        await _timeConstraint;

        var leagueClient = RestService.For<ISpectatorClient>($"https://{region}.api.riotgames.com", _settings);
        var response = await leagueClient.GetCurrentGame(encryptedSummonerId, _apiKey);
        return response;
    }
}