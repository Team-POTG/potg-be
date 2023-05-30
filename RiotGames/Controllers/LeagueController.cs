using System.Net;
using Microsoft.AspNetCore.Mvc;
using potg.RiotGames.Dto.League;
using potg.RiotGames.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace potg.RiotGames.Controllers;

[Route("api/lol/[Controller]/{region}")]
[ApiExplorerSettings(GroupName = "League v4")]
[ApiController]
public class LeagueController : ControllerBase
{
    private readonly LeagueService _leagueService;

    public LeagueController(LeagueService leagueService)
    {
        _leagueService = leagueService;
    }

    [HttpGet]
    [SwaggerOperation(OperationId = "GetLeagueEntries")]
    [ProducesResponseType(typeof(IEnumerable<LeagueEntryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("by-summoner/{encryptedSummonerId}")]
    public async Task<IActionResult> GetLeagueEntries(string encryptedSummonerId, string region = "kr")
    {
        try
        {
            using var entry = await _leagueService.GetLeagueEntries(encryptedSummonerId, region);
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