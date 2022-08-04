using lolAPI.Model.Enums;
using lolAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace lolAPI.Controllers;

public class MatchesController : Controller
{
    private readonly MatchesService _matchesService;

    public MatchesController(MatchesService matchesService)
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
}