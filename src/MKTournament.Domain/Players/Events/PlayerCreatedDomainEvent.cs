using MKTournament.Domain.Common;

namespace MKTournament.Domain.Players.Events;

/// <summary>
/// This domain event needs to be handled when a player just created his account in the app.
/// </summary>
/// <param name="PlayerId"></param>
public record PlayerCreatedDomainEvent(Guid PlayerId) : IDomainEvent;