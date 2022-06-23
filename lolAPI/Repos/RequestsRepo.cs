using lolAPI.Data;
using lolAPI.Model;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using RestSharp.Authenticators;

namespace lolAPI.Repos;

public class RequestsRepo
{
    private readonly lolAPIdb _db;

    public RequestsRepo(lolAPIdb db)
    {
        _db = db;
    }
    
    public async Task<string?> GetRequest(string baseUrl, string requestUrl)
    {
        var url = string.Concat(baseUrl + requestUrl);
        var requestFromDb = await _db.Request.FirstOrDefaultAsync(x => x.Url == url);
        // if (requestFromDb != null && DateTime.Now <= requestFromDb.DateCreated.AddMinutes(1))
        if (requestFromDb != null && DateTime.Now <= requestFromDb.DateCreated.AddMinutes(60)) //for tests
        {
            return requestFromDb.Json;
        }
        else
        {
            if (requestFromDb != null)
            {
                _db.Remove(requestFromDb);
            }
            var client = new RestClient(baseUrl);
            var request = new RestRequest(requestUrl);
            request.AddHeader("Accept", "application/json");
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                if (response.Content != null)
                {
                    await _db.Request.AddAsync(new Request
                    {
                        DateCreated = DateTime.Now,
                        Json = response.Content,
                        Url = string.Concat(baseUrl + requestUrl)
                    });
                    await _db.SaveChangesAsync();
                    return response.Content;
                }
            }
        }
        return null;
    }
}