using lolAPI.Model;
using lolAPI.Model.Enums;

namespace lolAPI.Interfaces;

public interface ISummonersService
{
    public Task<Summoner?> GetSummonerByName(Platforms platform, string summonerName);
}