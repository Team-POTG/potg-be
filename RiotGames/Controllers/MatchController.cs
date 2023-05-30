using System.Net;
using Microsoft.AspNetCore.Mvc;
using potg.RiotGames.Dto.Match;
using potg.RiotGames.Services;
using potg.RiotGames.Types;
using Swashbuckle.AspNetCore.Annotations;

namespace potg.RiotGames.Controllers;

[Route("api/lol/[Controller]/{region}")]
[ApiExplorerSettings(GroupName = "Match v5")]
[ApiController]
public class MatchController : ControllerBase
{
    private readonly MatchService _matchService;

    public MatchController(MatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpGet]
    [Tags("Matches")]
    [SwaggerOperation(OperationId = "GetMatches")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("by-puuid/{puuid}/ids")]
    public async Task<IActionResult> GetMatches(string puuid, string region = "asia", [FromQuery] long? startTime = null, [FromQuery] long? endTime = null, [FromQuery] QueueType? queueType = null, [FromQuery] string? type = null, [FromQuery] int start = 0, [FromQuery] int count = 20)
    {
        //TODO: DB에서 가져오기 시도

        try
        {
            //TODO: 저장
            using var entry = await _matchService.GetMatches(puuid, region, startTime, endTime, queueType, type, start, count);
            return StatusCode(200, entry.Content);
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

    [HttpGet]
    [Tags("Match")]
    [SwaggerOperation(OperationId = "GetMatch")]
    [ProducesResponseType(typeof(MatchDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("matches/{matchId}")]
    public async Task<IActionResult> GetMatch(string matchId, string region = "asia")
    {
        //TODO: DB에서 가져오기 시도

        try
        {
            //TODO: 저장
            using var entry = await _matchService.GetMatch(matchId, region);
            return StatusCode(200, entry.Content);
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