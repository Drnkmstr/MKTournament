namespace MKTournament.Domain.Common;

public abstract class BaseEntity(Guid id)
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public Guid Id { get; private set; } = id;

    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

    public void ClearDomainEvents() => _domainEvents.Clear();

    public void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}