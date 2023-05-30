using potg.Database.Entities.Match.Timeline.Events.Interfaces;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record ObjectiveBountyFinishEvent : EventEntity, ITeamEvent
{
    public byte TeamId { get; init; }
}