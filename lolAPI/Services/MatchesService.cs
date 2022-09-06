using lolAPI.Interfaces;
using lolAPI.Model.Enums;
using lolAPI.Repos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace lolAPI.Services;

public class MatchesService : IMatchesService
{
    private readonly ServersRepo _servers;
    private readonly RequestsRepo _requests;
    private readonly QueueFiltersRepo _queueFilters;
    private readonly JsonRepo _jsonRepo;
    private readonly SummonersService _summonersService;

    public MatchesService(ServersRepo servers, RequestsRepo requests,QueueFiltersRepo queueFilters, JsonRepo jsonRepo, SummonersService summonersService)
    {
        _servers = servers;
        _requests = requests;
        _queueFilters = queueFilters;
        _jsonRepo = jsonRepo;
        _summonersService = summonersService;
    }
    public async Task<string> GetLastMatchesId(string puuId,int? count, Regions regions, QueueType? queueType = null, QueueIds? queueIds = null)
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
            return _jsonRepo.FormatResponse(response);
        }
        return null;
    }

    public async Task<string?> GetMatchByMatchId(string matchId, Regions regions)
    {
        var baseUrl = _servers.RegionsRouting(regions);
        var requestUrl = string.Concat("/lol/match/v5/matches/", matchId);
        var response = await _requests.GetMatchRequest(baseUrl, requestUrl);
        if (response != null)
        {
            return response;
        }
        return null;
    }
    public async Task<string> GetLastMatchesBySummonerName(Platforms platforms, string summonerName, int? count, QueueType? queueType = null, QueueIds? queueIds = null)
    {
        var response = new JObject();
        var region = Regions.EUROPE;
        if (platforms is Platforms.BR1 or Platforms.NA1 or Platforms.LA1 or Platforms.LA2 or Platforms.OC1)
        {
            region = Regions.AMERICAS;
        }
        if (platforms is Platforms.JP1 or Platforms.KR or Platforms.OC1)
        {
            region = Regions.ASIA;
        }
        var user = await _summonersService.GetSummonerByName(platforms, summonerName);
        var data = JObject.Parse(user);
        string matchList = await GetLastMatchesId(data.GetValue("puuid").ToString(), count, region, queueType, queueIds);
        response.Add(new JProperty("summoner", data));
        var matches = new JArray();
        var matchesIds = JsonConvert.DeserializeObject<List<string>>(matchList);
        foreach (var m in matchesIds)
        { 
           matches.Add( JsonConvert.DeserializeObject(await GetMatchByMatchId(m, region)));
        }
        response.Add(new JProperty("matches", matches));
        return JsonConvert.SerializeObject(response, Formatting.Indented);
    }
}