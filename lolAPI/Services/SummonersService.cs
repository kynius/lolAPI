using lolAPI.Interfaces;
using lolAPI.Model.Enums;
using lolAPI.Repos;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace lolAPI.Services;

public class SummonersService : ISummonersService
{
    private readonly RequestsRepo _requestsRepo;
    private readonly ServersRepo _serversRepo;
    private readonly JsonRepo _jsonRepo;
    public SummonersService(RequestsRepo requestsRepo, ServersRepo serversRepo, ConfigRepo configRepo, JsonRepo jsonRepo)
    {
        _requestsRepo = requestsRepo;
        _serversRepo = serversRepo;
        _jsonRepo = jsonRepo;
    }
    public async Task<string?> GetSummonerByName(Platforms platform, string summonerName)
    {
            var serverUrl = _serversRepo.PlatformRouting(platform);
            var requestUrl = String.Concat("/lol/summoner/v4/summoners/by-name/" + summonerName);
            var response = await _requestsRepo.GetRequest(serverUrl, requestUrl);
            if (response != null)
            {
                return _jsonRepo.FormatResponse(response);
            }
            return null;
    }

    public async Task<string?> GetChampionMasteryBySummonerId(Platforms platforms,string summonerId)
    {
        var serverUrl = _serversRepo.PlatformRouting(platforms);
        var requestUrl = String.Concat("/lol/champion-mastery/v4/champion-masteries/by-summoner/" + summonerId);
        var response = await _requestsRepo.GetRequest(serverUrl, requestUrl);
        if (response != null)
        {
            return _jsonRepo.FormatResponse(response);
        }
        return null;
    }

    public async Task<string?> GetSummonerRankBySummonerId(Platforms platforms, string summonerId)
    {
        var serverUrl = _serversRepo.PlatformRouting(platforms);
        var requestUrl = string.Concat("/lol/league/v4/entries/by-summoner/" + summonerId);
        var response = await _requestsRepo.GetRequest(serverUrl, requestUrl);
        if (response != null)
        {
            return _jsonRepo.FormatResponse(response);
        }
        return null;
    }
}