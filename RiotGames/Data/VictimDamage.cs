using Newtonsoft.Json;

namespace potg.RiotGames.Data;

public sealed record VictimDamage
{
    [JsonProperty("basic")]
    public bool Basic { get; init; }

    [JsonProperty("magicDamage")]
    public long MagicDamage { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("participantId")]
    public long ParticipantId { get; init; }

    [JsonProperty("physicalDamage")]
    public long PhysicalDamage { get; init; }

    [JsonProperty("spellName")]
    public string SpellName { get; init; }

    [JsonProperty("spellSlot")]
    public long SpellSlot { get; init; }

    [JsonProperty("trueDamage")]
    public long TrueDamage { get; init; }

    [JsonProperty("type")]
    public string DamageDealtType { get; init; }
}