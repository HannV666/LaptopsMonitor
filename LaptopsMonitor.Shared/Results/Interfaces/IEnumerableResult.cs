namespace LaptopsMonitor.Shared.Results.Interfaces;

public interface IEnumerableResult<out T> : IDataResult<IEnumerable<T>>
{ }