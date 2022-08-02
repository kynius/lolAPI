using lolAPI.Model.Enums;

namespace lolAPI.Interfaces;

public interface IServersRepo
{
    public string PlatformRouting(Platforms platform);
    public string RegionsRouting(Regions region);
}