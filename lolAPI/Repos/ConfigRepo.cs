using lolAPI.Interfaces;
using lolAPI.Model;

namespace lolAPI.Repos;

public class ConfigRepo : IConfigRepo
{
    private IConfiguration _configuration;

    public ConfigRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Config GetConfig()
    {
        var apiToken = _configuration.GetSection("MyConfig").GetSection("ApiToken").Value;
        var appName = _configuration.GetSection("MyConfig").GetSection("AppName").Value;
        if (apiToken != null &&
            appName != null)
        {
            return new Config
            {
                ApiToken = apiToken,
                AppName = appName
            };
        }
        return new Config();
    }
}