using Microsoft.EntityFrameworkCore;
using MKTournament.Domain.Abstractions;

namespace MKTournament.Infrastructure.Persistence;

public class ApplicationDbContext(
    DbContextOptions options)
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
        //TODO : Add domain events in DB for later use with hangfire.
        
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}