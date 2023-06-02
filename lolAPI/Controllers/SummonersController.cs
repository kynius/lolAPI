using lolAPI.Interfaces;
using lolAPI.Model.Enums;
using Microsoft.AspNetCore.Mvc;

namespace lolAPI.Controllers
{
    [ApiController]
 
    public class SummonersController : ApiController
    {
        private readonly ISummonersService _summonersService;

        public SummonersController(ISummonersService summonersService)
        {
            _summonersService = summonersService;
        }
        
        [HttpGet("{platforms}/{summonerName}")]
        public async Task<IActionResult> GetSummoner(Platforms platforms,string summonerName)
        {
            var result = await _summonersService.GetSummonerByName(platforms, summonerName);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("/champion-mastery/{platforms}/{summonerId}")]
        public async Task<IActionResult> GetChampionMastery(Platforms platforms, string summonerId)
        {
            var result = await _summonersService.GetChampionMasteryBySummonerId(platforms, summonerId);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }[HttpGet("/champion-ranks/{platforms}/{summonerId}")]
        public async Task<IActionResult> GetSummonerRanks(Platforms platforms, string summonerId)
        {
            var result = await _summonersService.GetSummonerRankBySummonerId(platforms, summonerId);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
