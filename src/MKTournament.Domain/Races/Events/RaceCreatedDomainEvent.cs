using MKTournament.Domain.Common;

namespace MKTournament.Domain.Races.Events;

public record RaceCreatedDomainEvent(Guid raceId) : IDomainEvent;