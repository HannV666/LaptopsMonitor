using LaptopsMonitor.Shared.Results.Interfaces;

namespace LaptopsMonitor.Shared.Results.Primitives;

public class PagedResult<T> : IPagedResult<T>
{
    public bool IsSuccessful { get; init; }
    public string? Message { get; init; }
    public IEnumerable<T>? Data { get; init; }
    public int Page { get; init; }
    public int TotalPages { get; init; }
}