using LaptopsMonitor.Shared.Domain.Results.Interfaces;

namespace LaptopsMonitor.Shared.Domain.Results.Base;

public abstract class ResultBase : IResult
{
    public bool IsSuccess { get; init; }
    
    public string Message { get; init; } = string.Empty;
}

public abstract class ResultBase<T> : ResultBase
{
    public T? Data { get; init; }
}
