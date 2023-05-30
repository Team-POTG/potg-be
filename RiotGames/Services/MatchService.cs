using ComposableAsync;
using Microsoft.Extensions.Options;
using Nito.AsyncEx;
using potg.RiotGames.Clients;
using potg.RiotGames.Dto.Match;
using potg.RiotGames.Types;
using RateLimiter;
using Refit;

namespace potg.RiotGames.Services;

public class MatchService
{
    private readonly string _apiKey;
    private readonly RefitSettings _settings = new(new NewtonsoftJsonContentSerializer());
    private readonly TimeLimiter _matchesTimeConstraint = TimeLimiter.GetFromMaxCountByInterval(500, TimeSpan.FromSeconds(10));
    private readonly TimeLimiter _matchTimeConstraint = TimeLimiter.GetFromMaxCountByInterval(250, TimeSpan.FromSeconds(10));
    private readonly TimeLimiter _matchTimelineTimeConstraint = TimeLimiter.GetFromMaxCountByInterval(250, TimeSpan.FromSeconds(10));

    private readonly AsyncLock _matchLock = new();
    private readonly AsyncLock _matchTimelineLock = new();

    public MatchService(IOptions<RiotApiConfiguration> options) => _apiKey = options.Value.ApiKey;

    public async Task<ApiResponse<IEnumerable<string>>> GetMatches(string puuid, string region, long? startTime, long? endTime, QueueType? queue, string? type, int start, int count)
    {
        await _matchesTimeConstraint;

        var matchClient = RestService.For<IMatchClient>($"https://{region}.api.riotgames.com", _settings);
        var response = await matchClient.GetMatches(_apiKey, puuid, startTime, endTime, (int?) queue, type, start, count);
        return response;
    }

    public async Task<ApiResponse<MatchDto>> GetMatch(string matchId, string region)
    {
        using (await _matchLock.LockAsync())
        {
            await _matchTimeConstraint;
        }

        var matchClient = RestService.For<IMatchClient>($"https://{region}.api.riotgames.com", _settings);
        var response = await matchClient.GetMatch(_apiKey, matchId);
        return response;
    }

    public async Task<ApiResponse<MatchTimelineDto>> GetMatchTimeline(string matchId, string region)
    {
        using (await _matchTimelineLock.LockAsync())
        {
            await _matchTimelineTimeConstraint;
        }

        var matchClient = RestService.For<IMatchClient>($"https://{region}.api.riotgames.com", _settings);
        var response = await matchClient.GetMatchTimeline(_apiKey, matchId);
        return response;
    }
}