using lolAPI.Model;
using lolAPI.Model.Enums;
using Newtonsoft.Json.Linq;

namespace lolAPI.Interfaces;

public interface ISummonersService
{
    public Task<string?> GetSummonerByName(Platforms platform, string summonerName);
    public Task<string?> GetChampionMasteryBySummonerId(Platforms platforms, string summonerId);
    public Task<string?> GetSummonerRankBySummonerId(Platforms platforms, string summonerId);
}