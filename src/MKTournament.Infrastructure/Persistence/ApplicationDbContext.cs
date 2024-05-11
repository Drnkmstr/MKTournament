using MediatR;
using Microsoft.EntityFrameworkCore;
using MKTournament.Domain.Abstractions;
using MKTournament.Domain.Common;

namespace MKTournament.Infrastructure.Persistence;

public class ApplicationDbContext(
    DbContextOptions options,
    IPublisher publisher)
    : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Will apply all configurations found it this assembly.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        
        var domainEvents = GetDomainEvents();

        foreach (var domainEvent in domainEvents)
        {
            await publisher.Publish(domainEvent, cancellationToken);
        }

        return result;
    }

    private List<IDomainEvent> GetDomainEvents()
    {
        return ChangeTracker
            .Entries<BaseEntity>()
            .Select(e => e.Entity)
            .SelectMany(e =>
            {
                var domainEvents = e.GetDomainEvents();
                e.ClearDomainEvents();
                return domainEvents;
            })
            .ToList();
    }
}