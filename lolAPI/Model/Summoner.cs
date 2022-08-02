namespace lolAPI.Model;

public class Summoner
{
    [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
    public string Id { get; set; } = String.Empty!;
    [Newtonsoft.Json.JsonProperty(PropertyName = "accountId")]
    public string AccountId { get; set; } = String.Empty!;
    [Newtonsoft.Json.JsonProperty(PropertyName = "puuId")]
    public string PuuId { get; set; } = String.Empty!;
    [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
    public string Name { get; set; } = String.Empty!;
    [Newtonsoft.Json.JsonProperty(PropertyName = "profileIconId")]
    public int ProfileIconId { get; set; }
    [Newtonsoft.Json.JsonProperty(PropertyName = "summonerLevel")]
    public string SummonerLevel { get; set; } = String.Empty!;

    public Summoner()
    {
        
    }
}