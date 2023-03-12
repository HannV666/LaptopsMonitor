using LaptopsMonitor.Domain.Options.Primitives;
using LaptopsMonitor.Shared.Results.Interfaces;

namespace LaptopsMonitor.Domain.Interfaces;

public interface IRepository<T>
{
    Task<IEnumerableResult<T>> GetAsync(PageOptions pageOptions,
        FilterOptions<T>? options = default,
        CancellationToken cancellationToken = default);

    Task<IResult> BulkInsertAsync(IEnumerable<T> data, CancellationToken cancellationToken = default);
}