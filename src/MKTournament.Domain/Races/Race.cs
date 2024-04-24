using MKTournament.Domain.Common;

namespace MKTournament.Domain.Races;

public class Race(
    Guid id,
    RacePosition racePosition,
    Guid mapId,
    Guid grandPrixId)
    : BaseEntity(id)
{
    public int Position { get; } = racePosition.Value;
    public int Score { get; } = racePosition.Score;
    public Guid MapId { get; } = mapId;
    public Guid GrandPrixId { get; } = grandPrixId;
}