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
        if (_configuration.GetSection("MyConfig").GetSection("ApiToken").Value != null &&
            _configuration.GetSection("MyConfig").GetSection("AppName").Value != null)
        {
            return new Config
            {
                ApiToken = _configuration.GetSection("MyConfig").GetSection("ApiToken").Value,
                AppName = _configuration.GetSection("MyConfig").GetSection("AppName").Value
            };
        }
        return new Config();
    }
}