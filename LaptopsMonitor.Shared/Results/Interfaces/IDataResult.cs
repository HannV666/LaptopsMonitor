namespace LaptopsMonitor.Shared.Results.Interfaces;

public interface IDataResult<out T> : IResult
{
    T? Data { get; }
}