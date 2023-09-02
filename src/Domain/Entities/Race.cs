using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Race : BaseEntity
{
    public Race(string createdBy, RacePosition racePosition, Guid mapId, Guid grandPrixId, Guid id) : base(createdBy, id)
    {
        MapId = mapId;
        GrandPrixId = grandPrixId;
        Position = racePosition.Value;
        Score = racePosition.Score;
    }
    
    public int Position { get; }
    public int Score { get; }
    public Guid MapId { get; }
    public Guid GrandPrixId { get; }
}