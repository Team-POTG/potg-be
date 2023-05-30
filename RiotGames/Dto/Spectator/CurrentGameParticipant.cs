using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Spectator;

public sealed record CurrentGameParticipant
{
    [JsonProperty("teamId")]
    public int TeamId { get; init; }

    [JsonProperty("spell1Id")]
    public int Spell1Id { get; init; }

    [JsonProperty("spell2Id")]
    public int Spell2Id { get; init; }

    [JsonProperty("championId")]
    public int ChampionId { get; init; }

    [JsonProperty("profileIconId")]
    public int ProfileIconId { get; init; }

    [JsonProperty("summonerName")]
    public string SummonerName { get; init; }

    [JsonProperty("bot")]
    public bool Bot { get; init; }

    [JsonProperty("summonerId")] 
    public string SummonerId { get; init; }

    [JsonProperty("perks")]
    public Perks Perks { get; init; }
}