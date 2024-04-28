using ErrorOr;

namespace MKTournament.Domain.Common;

public interface IBaseEntityRepository<T>
where T : BaseEntity
{
    Task<ErrorOr<T?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ErrorOr<Deleted>> RemoveAsync(T entity, CancellationToken cancellationToken = default);

    Task<ErrorOr<Created>> AddAsync(T entity, CancellationToken cancellationToken = default);
}