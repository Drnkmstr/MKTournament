using Microsoft.EntityFrameworkCore;
using MKTournament.Domain.Common;
using MKTournament.Infrastructure.Persistence;

namespace MKTournament.Infrastructure.Repositories;

public abstract class BaseRepository<T>(
    ApplicationDbContext dbContext)
    : IBaseEntityRepository<T>
where T : BaseEntity
{
    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Set<T>()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void RemoveAsync(T entity, CancellationToken cancellationToken = default)
    {
        dbContext.Remove(entity);
    }

    public void Add(T entity, CancellationToken cancellationToken = default)
    {
        dbContext.Add(entity);
    }
}