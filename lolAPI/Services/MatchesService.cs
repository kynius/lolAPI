using lolAPI.Interfaces;
using lolAPI.Model;
using lolAPI.Model.Enums;
using lolAPI.Repos;
using Newtonsoft.Json;

namespace lolAPI.Services;

public class MatchesService : IMatchesService
{
    private readonly ServersRepo _servers;
    private readonly RequestsRepo _requests;
    private readonly QueueFiltersRepo _queueFilters;

    public MatchesService(ServersRepo servers, RequestsRepo requests,QueueFiltersRepo queueFilters)
    {
        _servers = servers;
        _requests = requests;
        _queueFilters = queueFilters;
    }
    public async Task<List<string>?> GetLastMatchesId(string puuId,int? count, QueueType? queueType, QueueIds? queueIds, Regions regions)
    {
        var baseUrl = _servers.RegionsRouting(regions);
        string? countUrl = null;
        string? queueTypeUrl = null;
        if (count != null)
        {
            countUrl = _queueFilters.ReturnCountUrl(count.Value);
        }
        if (queueType != null && queueIds == null)
        {
            queueTypeUrl = String.Concat("&" + _queueFilters.ReturnQueueTypeUrlByEnum(queueType.Value));
        }
        if (queueIds != null && queueType == null)
        {
            queueTypeUrl = String.Concat("&" + _queueFilters.ReturnQueueIdUrl(queueIds.Value));
        }
        var requestUrl = String.Concat("/lol/match/v5/matches/by-puuid/" + puuId + "/ids" + "?" + countUrl + queueTypeUrl);
        var response = await _requests.GetRequest(baseUrl, requestUrl);
        if (response != null)
        {
            List<string> matchesId = JsonConvert.DeserializeObject<List<string>>(response);
            return matchesId;
        }
        return null;
    }

    public async Task<Match?> GetMatchByMatchId(string matchId, Regions regions)
    {
        var baseUrl = _servers.RegionsRouting(regions);
        var requestUrl = string.Concat("/lol/match/v5/matches/", matchId);
        var response = await _requests.GetRequest(baseUrl, requestUrl);
        if (response != null)
        {
            return JsonConvert.DeserializeObject<Match>(response);
        }
        return null;
    }
}