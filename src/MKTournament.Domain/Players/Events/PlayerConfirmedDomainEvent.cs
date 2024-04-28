using MKTournament.Domain.Common;

namespace MKTournament.Domain.Players.Events;

/// <summary>
/// This domain event needs to be handled when a player just confirmed his email address.
/// </summary>
/// <param name="PlayerId"></param>
public record PlayerConfirmedDomainEvent(Guid PlayerId) : IDomainEvent;