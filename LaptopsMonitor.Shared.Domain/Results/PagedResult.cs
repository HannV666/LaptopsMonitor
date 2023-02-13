using LaptopsMonitor.Shared.Domain.Results.Base;

namespace LaptopsMonitor.Shared.Domain.Results;

public class PagedResult<T> : ResultBase<IEnumerable<T>>
{
    public int CurrentPage { get; init; }

    public int TotalPages { get; init; }
}
