using MKTournament.Domain.Common;

namespace MKTournament.Domain.Races.Events;

public record RaceFinishedDomainEvent(Guid raceId) : IDomainEvent;