using lolAPI.Model.Enums;

namespace lolAPI.Interfaces;

public interface IQueueFiltersRepo
{
    public string? ReturnQueueTypeUrlByEnum(QueueType type);
    public string? ReturnCountUrl(int count);
    public string? ReturnQueueIdUrl(QueueIds queueIds);
}