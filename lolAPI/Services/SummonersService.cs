using lolAPI.Model.Enums;
using lolAPI.Repos;

namespace lolAPI.Services;

public class SummonersService
{
    private readonly RequestsRepo _requestsRepo;
    private readonly ServersRepo _serversRepo;
    private readonly ConfigRepo _configRepo;
    public SummonersService(RequestsRepo requestsRepo, ServersRepo serversRepo, ConfigRepo configRepo)
    {
        _requestsRepo = requestsRepo;
        _serversRepo = serversRepo;
        _configRepo = configRepo;
    }
    public async Task<string?> GetSummonerByName(Platforms platform, string summonerName)
    {
            var token = _configRepo.GetConfig().ApiToken;
            var serverUrl = _serversRepo.PlatformRouting(platform);
            var response = await _requestsRepo.GetRequest(serverUrl,
                String.Concat("/lol/summoner/v4/summoners/by-name/" + summonerName + token));
            return response;
    }
}