using MongoDB.Bson.Serialization.Attributes;
using potg.Database.Entities.Match.Timeline.Events.Interfaces;
using potg.RiotGames.Data;

namespace potg.Database.Entities.Match.Timeline.Events;

public record BuildingKillEvent : KillEvent, IBountyAttachableEvent, IPositionalEvent, ITeamEvent, ILaneSpecificEvent
{
    public long Bounty { get; init; }

    public long? ShutdownBounty { get; init; }

    [BsonElement("buildingType")]
    public string BuildingType { get; init; }

    public Position Position { get; init; }

    public byte TeamId { get; init; }

    public string LaneType { get; init; }
}