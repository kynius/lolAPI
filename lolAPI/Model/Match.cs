namespace lolAPI.Model;

public class Match
{
    public int MatchId { get; set; }
    public List<string> Participants { get; set;}
    public int GameDuration { get; set; }
    public int MapId { get; set; }
    public List<Player> Players { get; set; }
    public int QueueId { get; set; }
    public List<Team> Teams { get; set; }
}