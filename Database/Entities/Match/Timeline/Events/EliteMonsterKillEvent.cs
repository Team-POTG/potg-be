using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Entities.Match.Timeline.Events.Interfaces;
using potg.RiotGames.Data;

namespace potg.Database.Entities.Match.Timeline.Events;

public record EliteMonsterKillEvent : KillEvent, IAssistableEvent, IBountyAttachableEvent, IPositionalEvent
{
    public IEnumerable<long> AssistingParticipantIds { get; init; }

    public long Bounty { get; init; }

    public long? ShutdownBounty { get; init; }

    public Position Position { get; init; }

    [BsonElement("monsterType")]
    public string MonsterType { get; init; }

    [BsonElement("killerTeamId")]
    public int KillerTeamId { get; init; }
}