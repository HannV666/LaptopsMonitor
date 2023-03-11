using LaptopsMonitor.Shared.Results.Interfaces;

namespace LaptopsMonitor.Shared.Results.Primitives;

public class EnumerableResult<T> : IEnumerableResult<T>
{
    public bool IsSuccessful { get; init; }
    public string? Message { get; init; }
    public IEnumerable<T>? Data { get; init; }
}