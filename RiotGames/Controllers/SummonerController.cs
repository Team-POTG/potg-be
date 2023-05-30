using System.Net;
using Microsoft.AspNetCore.Mvc;
using potg.RiotGames.Dto.Summoner;
using potg.RiotGames.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace potg.RiotGames.Controllers;

[Route("api/lol/[Controller]/{region}")]
[ApiExplorerSettings(GroupName = "Summoner v4")]
[ApiController]
public class SummonerController : ControllerBase
{
    private readonly SummonerService _summonerService;

    public SummonerController(SummonerService summonerService)
    {
        _summonerService = summonerService;
    }

    [HttpGet]
    [SwaggerOperation(OperationId = "GetSummoner")]
    [ProducesResponseType(typeof(SummonerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("by-name/{summonerName}")]
    public async Task<IActionResult> GetSummoner(string summonerName, string region = "KR")
    {
        //TODO: DB에서 가져오기 시도

        try
        {
            //TODO: 저장
            using var summoner = await _summonerService.GetSummoner(summonerName, region);
            return StatusCode(200, summoner);
        }
        catch (WebException)
        {
            return StatusCode(500, "존재하지 않는 유저");
        }
        catch (Exception ex)
        {
            //TODO: 로그
            return StatusCode(500, "알 수 없는 오류");
        }
    }
}
