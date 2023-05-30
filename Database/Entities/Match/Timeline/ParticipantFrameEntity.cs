using Newtonsoft.Json;
using potg.RiotGames.Data;

namespace potg.Database.Entities.Match.Timeline;

public sealed record ParticipantFrameEntity
{
    [JsonProperty("championStats")]
    public IDictionary<string, long> ChampionStats { get; init; }

    [JsonProperty("currentGold")]
    public int CurrentGold { get; init; }

    [JsonProperty("damageStats")]
    public IDictionary<string, long> DamageStats { get; init; }

    [JsonProperty("goldPerSecond")]
    public int GoldPerSecond { get; init; }

    [JsonProperty("jungleMinionsKilled")]
    public int JungleMinionsKilled { get; init; }

    [JsonProperty("level")]
    public int Level { get; init; }

    [JsonProperty("minionsKilled")]
    public int MinionsKilled { get; init; }

    [JsonProperty("participantId")]
    public int ParticipantId { get; init; }

    [JsonProperty("position")]
    public Position Position { get; init; }

    [JsonProperty("timeEnemySpentControlled")]
    public int TimeEnemySpentControlled { get; init; }

    [JsonProperty("totalGold")]
    public int TotalGold { get; init; }

    [JsonProperty("xp")]
    public int Xp { get; init; }
}