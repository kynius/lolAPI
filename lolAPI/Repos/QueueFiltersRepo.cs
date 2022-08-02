using lolAPI.Interfaces;
using lolAPI.Model.Enums;

namespace lolAPI.Repos;

public class QueueFiltersRepo : IQueueFiltersRepo
{
    public string? ReturnQueueTypeUrlByEnum(QueueType type)
    {
        var queueTypeUrl = type switch
        {
            QueueType.NORMAL => "type=normal",
            QueueType.RANKED => "type=ranked",
            _ => "Queue type not found"
        };
        return queueTypeUrl;
    }
    
    public string? ReturnCountUrl(int count)
    {
        return String.Concat("count=", count);
    }

    public string? ReturnQueueIdUrl(QueueIds queueIds)
    {
        var queueIdUrl = queueIds switch
        { 
            QueueIds.SOLO_DUO => "queue=420", 
            QueueIds.FLEX => "queue=440",
            QueueIds.ARAM => "queue=450",
            _ => "QueueId not exist"
        };
        return queueIdUrl;
    }
}