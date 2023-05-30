using ComposableAsync;
using Microsoft.Extensions.Options;
using potg.RiotGames.Clients;
using potg.RiotGames.Dto.Summoner;
using RateLimiter;
using Refit;

namespace potg.RiotGames.Services;

public class SummonerService
{
    private readonly string _apiKey;
    private readonly RefitSettings _settings = new(new NewtonsoftJsonContentSerializer());
    private readonly TimeLimiter _timeConstraint = TimeLimiter.GetFromMaxCountByInterval(1600, TimeSpan.FromMinutes(1));

    public SummonerService(IOptions<RiotApiConfiguration> options) => _apiKey = options.Value.ApiKey;

    /// <summary>
    /// 소환사 이름을 이용하여 소환사 정보를 가져옵니다.
    /// </summary>
    /// <param name="summonerName">소환사 이름</param>
    /// <param name="region">지역</param>
    /// <returns>소환사 정보</returns>
    public async Task<ApiResponse<SummonerDto>> GetSummoner(string summonerName, string region)
    {
        await _timeConstraint;

        var summonerClient = RestService.For<ISummonerClient>($"https://{region}.api.riotgames.com", _settings);
        var response = await summonerClient.GetSummonerByName(summonerName, _apiKey);
        return response;
    }
}