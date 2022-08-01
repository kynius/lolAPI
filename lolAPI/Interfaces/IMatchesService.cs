using lolAPI.Model;
using lolAPI.Model.Enums;

namespace lolAPI.Interfaces;

public interface IMatchesService
{
    public Task<List<string>?> GetLastMatchesId(string puuId,int? count, QueueType? queueType, QueueIds? queueIds, Regions regions );
    public Task<Match?> GetMatchByMatchId(string matchId, Regions regions);
}