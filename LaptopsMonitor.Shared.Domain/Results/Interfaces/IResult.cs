namespace LaptopsMonitor.Shared.Domain.Results.Interfaces;

public interface IResult
{
    bool IsSuccess { get; }

    string Message { get; }
}
