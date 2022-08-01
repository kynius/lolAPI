namespace lolAPI.Model;

public class Player
{
    public string PuuId { get; set; }
    public string Name { get; set; }
    public int ChampLevel { get; set; }
    public int ChampionId { get; set; }
    public string ChampionName { get; set; }
    public int DamageSelfMitigated { get; set; }
    public int Kills { get; set; }
    public int Deaths { get; set; }
    public int Assists { get; set; }
    public bool FirstBloodKill { get; set; }
    public bool FirstTowerKill { get; set; }
    public bool FirstTowerAssist { get; set; }
    public string GoldEarned { get; set; }
    public string IndividualPosition { get; set; }
    public int Item0 { get; set; }
    public int Item1 { get; set; }
    public int Item2 { get; set; }
    public int Item3 { get; set; }
    public int Item4 { get; set; }
    public int Item5 { get; set; }
    public int Item6 { get; set; }
    public int StatDefense { get; set; }
    public int StatFlex { get; set; }
    public int StatOffense { get; set; }
    public int PrimaryStyle { get; set; }
    public int PrimaryPerk1 { get; set; }
    public int PrimaryPerk2 { get; set; }
    public int PrimaryPerk3 { get; set; }
    public int PrimaryPerk4 { get; set; }
    public int SubStyle { get; set; }
    public int SubPerk1 { get; set; }
    public int SubPerk2 { get; set; }
    public int SummonerTypeId1 { get; set; }
    public int SummonerTypeId2 { get; set; }
    public int MagicDamageDealtToChampions { get; set; }
    public int PhysicalDamageDealtToChampions { get; set; }
    public int TrueDamageDealtToChampions { get; set; }
    public int TotalDamageDealtToChampions { get; set; }
    public int TotalDamageShieldedOnTeammates { get; set; }
    public int TotalDamageTaken { get; set; }
    public int TotalHealsOnTeammates { get; set; }
    public int TotalMinionsKilled { get; set; }
    public int TurretKills { get; set; }
    public int VisionScore { get; set; }
    public int VisionWardsBoughtInGame { get; set; }
}