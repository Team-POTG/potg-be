using System.Net;
using Microsoft.AspNetCore.Mvc;
using potg.Data.Dto;
using potg.Database.Repositories;
using potg.RiotGames.Services;
using potg.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace potg.Controllers;

[Route("api/potg-lol/[Controller]")]
[ApiExplorerSettings(GroupName = "POTG v1")]
[ApiController]
public class PotgController : ControllerBase
{
	private readonly SummonerRepository _summonerRepository;
	private readonly JobQueueService _jobQueue;

	public PotgController(SummonerRepository summonerRepository, LeagueService leagueService, JobQueueService jobQueue)
	{
		_summonerRepository = summonerRepository;
		_jobQueue = jobQueue;
	}

	[HttpGet]
	[SwaggerOperation(OperationId = "AutoComplete")]
	[ProducesResponseType(typeof(IEnumerable<SummonerSearchDto>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	[Route("auto-complete")]
	public async Task<IActionResult> GetSummoner([FromQuery] string query, [FromQuery] string region = "kr")
	{
		try
		{
			var result = await _summonerRepository.GetSummoners(query, region);
			return StatusCode(200, result);
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
	[Route("test")]
	public async Task<IActionResult> Test()
	{
		var task = new Task<string>(() =>
		{
			Thread.Sleep(1000);
			return "test";
		});
		var task2 = new Task<string>(() =>
		{
			Thread.Sleep(1000);
			return "test2";
		});
		var task3 = new Task<string>(() =>
		{
			Thread.Sleep(1000);
			return "test3";
		});

		_jobQueue.Push(task);
		_jobQueue.Push(task2);
		_jobQueue.Push(task3);

		Task.WaitAll(task, task2, task3);

		return Ok(new[] { task.Result, task2.Result, task3.Result });
	}
}