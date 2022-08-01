namespace lolAPI.Model;

public class Team
{
    public List<int> Bans { get; set; } = new List<int>();
    public int BaronKills { get; set; }
    public int ChampionKills { get; set; }
    public int DragonKills { get; set; }
    public int InhibitorKills { get; set; }
    public int TowerKills { get; set; }
    public int TeamId { get; set; }
    public bool Win { get; set; }
}