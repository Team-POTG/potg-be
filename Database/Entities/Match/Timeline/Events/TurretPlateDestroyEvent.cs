using potg.Database.Entities.Match.Timeline.Events.Interfaces;
using potg.RiotGames.Data;

namespace potg.Database.Entities.Match.Timeline.Events;

public sealed record TurretPlateDestroyEvent : KillEvent, ILaneSpecificEvent, IPositionalEvent, ITeamEvent
{
    public string LaneType { get; init; }

    public Position Position { get; init; }

    public byte TeamId { get; init; }
}