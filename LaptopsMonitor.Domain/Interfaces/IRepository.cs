using LaptopsMonitor.Domain.Entities.Interfaces;
using LaptopsMonitor.Shared.Domain.Results;

namespace LaptopsMonitor.Domain.Interfaces;

public interface IRepository<TKey, TStorableEntity> where TStorableEntity : class, IStorableEntity<TKey>
{
    Task<PagedResult<TStorableEntity>> GetAsync(int page, CancellationToken cancellationToken = default);

    Task<EmptyResult> AddRangeAsync(IEnumerable<TStorableEntity> entities, CancellationToken cancellationToken = default);
}
