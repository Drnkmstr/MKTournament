using MKTournament.Domain.Common;

namespace MKTournament.Domain.GrandPrixx.Events;

public record GrandPrixCreatedDomainEvent(Guid grandPrixId) : IDomainEvent;