using lolAPI.Interfaces;
using lolAPI.Model.Enums;
namespace lolAPI.Repos;

public class ServersRepo : IServersRepo
{
    public string PlatformRouting(Platforms platform)
    {
        string serverUrl;
        serverUrl = platform switch
        {
            Platforms.BR1 => "https://br1.api.riotgames.com",
            Platforms.EUN1 => "https://eun1.api.riotgames.com",
            Platforms.EUW1 => "https://euw1.api.riotgames.com",
            Platforms.JP1 => "https://jp1.api.riotgames.com",
            Platforms.KR => "https://kr.api.riotgames.com",
            Platforms.LA1 => "https://la1.api.riotgames.com",
            Platforms.LA2 => "https://la2.api.riotgames.com",
            Platforms.NA1 => "https://na1.api.riotgames.com",
            Platforms.OC1 => "https://oc1.api.riotgames.com",
            Platforms.TR1 => "https://tr1.api.riotgames.com",
            Platforms.RU => "https://ru.api.riotgames.com",
            _ => "Platform not exist"
        };
        return serverUrl;
    }
    public string RegionsRouting(Regions region)
    {
        string serverUrl;
        serverUrl = region switch
        {
            Regions.ASIA => "https://asia.api.riotgames.com",
            Regions.EUROPE => "https://europe.api.riotgames.com",
            Regions.AMERICAS => "https://americas.api.riotgames.com",
            _ => "Region not exist"
        };
        return serverUrl;
    }
}