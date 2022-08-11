namespace lolAPI.Interfaces;

public interface IRequestsRepo
{
    public Task<string?> GetRequest(string baseUrl, string requestUrl);
    public Task<string?> GetMatchRequest(string baseUrl, string requestUrl);
}