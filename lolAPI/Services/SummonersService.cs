using lolAPI.Interfaces;
using lolAPI.Model;
using lolAPI.Model.Enums;
using lolAPI.Repos;
using Newtonsoft.Json;

namespace lolAPI.Services;

public class SummonersService : ISummonersService
{
    private readonly RequestsRepo _requestsRepo;
    private readonly ServersRepo _serversRepo;
    public SummonersService(RequestsRepo requestsRepo, ServersRepo serversRepo, ConfigRepo configRepo)
    {
        _requestsRepo = requestsRepo;
        _serversRepo = serversRepo;
    }
    public async Task<Summoner?> GetSummonerByName(Platforms platform, string summonerName)
    {
            var serverUrl = _serversRepo.PlatformRouting(platform);
            var requestUrl = String.Concat("/lol/summoner/v4/summoners/by-name/" + summonerName);
            var response = await _requestsRepo.GetRequest(serverUrl, requestUrl
                );
            if (response != null)
            {
                var summoner = JsonConvert.DeserializeObject<Summoner>(response); 
                return summoner;
            }
            return null;
    }
}