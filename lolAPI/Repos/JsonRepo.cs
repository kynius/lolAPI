using lolAPI.Interfaces;
using Newtonsoft.Json;

namespace lolAPI.Repos;

public class JsonRepo : IJsonRepo
{
    public string? FormatResponse(string response)
    {
        var parsedJson = JsonConvert.DeserializeObject(response);
        var json = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        return json;
    }
}