using potg.Database.Entities.Match.Timeline.Events.Interfaces;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record ObjectiveBountyPreStartEvent : EventEntity, IActualTimeEvent, ITeamEvent
{
    public long ActualStartTime { get; init; }

    public byte TeamId { get; init; }
}