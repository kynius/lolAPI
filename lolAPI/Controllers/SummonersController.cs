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
        
        [HttpGet("{platform}/{summonerName}")]
        public async Task<IActionResult> Get(Platforms platform,string summonerName)
        {
            var result = await _summonersService.GetSummonerByName(platform, summonerName);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok();
        }
    }
}
