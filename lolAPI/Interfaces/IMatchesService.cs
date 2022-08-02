using lolAPI.Model;
using lolAPI.Model.Enums;

namespace lolAPI.Interfaces;

public interface IMatchesService
{
    public Task<string> GetLastMatchesId(string puuId,int? count, QueueType? queueType, QueueIds? queueIds, Regions regions );
    public Task<string?> GetMatchByMatchId(string matchId, Regions regions);
    public Task<string> GetLastMatchesBySummonerName(Platforms platforms, string summonerName, int? count, QueueType queueType, QueueIds queueIds);
}