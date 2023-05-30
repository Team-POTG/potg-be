using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Entities.Match.Timeline.Events.Interfaces;
using potg.RiotGames.Data;

namespace potg.Database.Entities.Match.Timeline.Events;

public record ChampionKillEvent : KillEvent, IAssistableEvent, IBountyAttachableEvent, IPositionalEvent
{
    public IEnumerable<long>? AssistingParticipantIds { get; init; }

    public long Bounty { get; init; }

    public long? ShutdownBounty { get; init; }

    public Position Position { get; init; }

    [BsonElement("killStreakLength")]
    public int KillStreakLength { get; init; }

    [BsonElement("victimDamageDealt")]
    public IEnumerable<VictimDamage>? VictimDamageDealt { get; init; }

    [BsonElement("victimDamageReceived")]
    public IEnumerable<VictimDamage>? VictimDamageReceived { get; init; }

    [BsonElement("victimId")]
    public int VictimId { get; init; }
}