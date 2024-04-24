using MKTournament.Domain.Common;

namespace MKTournament.Domain.Players.Events;

public record PlayerCreatedDomainEvent(Guid playerId) : IDomainEvent;