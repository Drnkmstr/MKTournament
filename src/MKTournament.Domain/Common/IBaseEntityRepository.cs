using MKTournament.Domain.Abstractions;

namespace MKTournament.Domain.Common;

public interface IBaseEntityRepository<T>
where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task RemoveAsync(T entity, CancellationToken cancellationToken = default);

    void Add(T entity, CancellationToken cancellationToken = default);
}