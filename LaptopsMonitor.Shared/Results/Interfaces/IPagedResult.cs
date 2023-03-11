namespace LaptopsMonitor.Shared.Results.Interfaces;

public interface IPagedResult<out T> : IEnumerableResult<T>
{
    int Page { get; }
    int TotalPages { get; }
}