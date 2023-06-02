using lolAPI.Interfaces;
using lolAPI.Model.Enums;
using lolAPI.Repos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace lolAPI.Services;

public class MatchesService : IMatchesService
{
    private readonly IServersRepo _servers;
    private readonly IRequestsRepo _requests;
    private readonly IQueueFiltersRepo _queueFilters;
    private readonly IJsonRepo _jsonRepo;
    private readonly ISummonersService _summonersService;

    public MatchesService(IServersRepo servers, IRequestsRepo requests,IQueueFiltersRepo queueFilters, IJsonRepo jsonRepo, ISummonersService summonersService)
    {
        _servers = servers;
        _requests = requests;
        _queueFilters = queueFilters;
        _jsonRepo = jsonRepo;
        _summonersService = summonersService;
    }
    public async Task<string?> GetLastMatchesId(string puuId,int? count, Regions regions, QueueType? queueType = null, QueueIds? queueIds = null)
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
        return response != null ? _jsonRepo.FormatResponse(response) : null;
    }

    public async Task<string?> GetMatchByMatchId(string matchId, Regions regions)
    {
        var baseUrl = _servers.RegionsRouting(regions);
        var requestUrl = string.Concat("/lol/match/v5/matches/", matchId);
        var response = await _requests.GetMatchRequest(baseUrl, requestUrl);
        return response ?? null;
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
        if (user != null)
        {
            var data = JObject.Parse(user);
            var puuId = data.GetValue("puuid");
            if (puuId != null)
            {
                var matchList = await GetLastMatchesId(puuId.ToString(), count, region, queueType, queueIds);
                if (matchList != null)
                {
                    response.Add(new JProperty("summoner", data));
                    var matches = new JArray();
                    var matchesIds = JsonConvert.DeserializeObject<List<string>>(matchList);
                    if (matchesIds != null && matchesIds.Any())
                    {
                        foreach (var m in matchesIds)
                        {
                            var match = await GetMatchByMatchId(m, region);
                            if (match != null)
                            {
                                matches.Add(JsonConvert.DeserializeObject(match));
                            }
                        }
                        response.Add(new JProperty("matches", matches));
                    }
                }
            }
        }
        return JsonConvert.SerializeObject(response, Formatting.Indented);
    }

    public async Task<string?> GetActiveMatchBySummonerName(Platforms platforms, string summonerName)
    {
        var baseURl = _servers.PlatformRouting(platforms);
        var user = await _summonersService.GetSummonerByName(platforms, summonerName);
        if (user != null)
        {
            var data = JObject.Parse(user);
            var id = data.GetValue("id");
            if (id != null)
            {
                var requestUrl =
                    string.Concat("/lol/spectator/v4/active-games/by-summoner/", id.ToString());
                var response = await _requests.GetRequest(baseURl, requestUrl);
                return response != null ? _jsonRepo.FormatResponse(response) : null;
            }
        }
        return null;
    }
}