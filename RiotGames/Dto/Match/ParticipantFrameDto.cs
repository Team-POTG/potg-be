using Newtonsoft.Json;
using potg.RiotGames.Data;

namespace potg.RiotGames.Dto.Match;

public sealed record ParticipantFrameDto
{
    [JsonProperty("championStats")]
    public IReadOnlyDictionary<string, long> ChampionStats { get; init; }

    [JsonProperty("currentGold")]
    public long CurrentGold { get; init; }

    [JsonProperty("damageStats")]
    public IReadOnlyDictionary<string, long> DamageStats { get; init; }

    [JsonProperty("goldPerSecond")]
    public long GoldPerSecond { get; init; }

    [JsonProperty("jungleMinionsKilled")]
    public long JungleMinionsKilled { get; init; }

    [JsonProperty("level")]
    public long Level { get; init; }

    [JsonProperty("minionsKilled")]
    public long MinionsKilled { get; init; }

    [JsonProperty("participantId")]
    public long ParticipantId { get; init; }

    [JsonProperty("position")]
    public Position Position { get; init; }

    [JsonProperty("timeEnemySpentControlled")]
    public long TimeEnemySpentControlled { get; init; }

    [JsonProperty("totalGold")]
    public long TotalGold { get; init; }

    [JsonProperty("xp")]
    public long Xp { get; init; }
}