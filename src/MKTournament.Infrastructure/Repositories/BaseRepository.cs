using Microsoft.EntityFrameworkCore;
using MKTournament.Domain.Common;
using MKTournament.Infrastructure.Persistence;

namespace MKTournament.Infrastructure.Repositories;

public abstract class BaseRepository<T>(
    ApplicationDbContext dbContext)
    : IBaseEntityRepository<T>
    where T : BaseEntity
{
    protected readonly DbSet<T> DbContext = dbContext.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void RemoveAsync(T entity, CancellationToken cancellationToken = default)
    {
        DbContext.Remove(entity);
    }

    public virtual void Add(T player)
    {
        DbContext.Add(player);
    }
}