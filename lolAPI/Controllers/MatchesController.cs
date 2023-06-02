using lolAPI.Interfaces;
using lolAPI.Model.Enums;
using Microsoft.AspNetCore.Mvc;

namespace lolAPI.Controllers;

public class MatchesController : Controller
{
    private readonly IMatchesService _matchesService;

    public MatchesController(IMatchesService matchesService)
    {
        _matchesService = matchesService;
    }

    [HttpGet("/by-puuid/{regions}/{puuId}")]
    public async Task<IActionResult> GetLastMatchesByPuuId(string puuId, Regions regions,QueueType? queueType, QueueIds? queueIds, int count = 10)
    {
        var response = await _matchesService.GetLastMatchesId(puuId, count, regions, queueType, queueIds);
        if (response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }
    [HttpGet("/by-matchId/{regions}/{matchId}")]
    public async Task<IActionResult> GetMatchById(Regions regions, string matchId)
    {
        var response = await _matchesService.GetMatchByMatchId(matchId, regions);
        if (response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }
    [HttpGet("/by-summonerName/{platforms}/{summonerName}")]
    public async Task<IActionResult> GetLastMatchesBySummonerName(Platforms platforms, string summonerName,
        QueueType? queueType = null, QueueIds? queueIds = null, int? count = 20)
    {
        var response =
           await _matchesService.GetLastMatchesBySummonerName(platforms, summonerName, count, queueType, queueIds);
        if (response.Any())
        {
            return Ok(response);
        }
        return NotFound();
    }
    [HttpGet("/live-game/by-summonerName/{platforms}/{summonerName}")]
    public async Task<IActionResult> GetLiveGameByUserName(Platforms platforms, string summonerName)
    {
        var response =
            await _matchesService.GetActiveMatchBySummonerName(platforms, summonerName);
        if (response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }
}