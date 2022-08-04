using lolAPI.Model.Enums;
using lolAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace lolAPI.Controllers
{
    [ApiController]
 
    public class SummonersController : ApiController
    {
        private readonly SummonersService _summonersService;

        public SummonersController(SummonersService summonersService)
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
        }
    }
}
