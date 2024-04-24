namespace MKTournament.Domain.Common;

public abstract class BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    
    protected BaseEntity(Guid id)
    {
        Id = id;
    }

    protected BaseEntity()
    {
        
    }
    
    public Guid Id { get; }

    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

    public void ClearDomainEvents() => _domainEvents.Clear();

    public void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}