namespace LaptopsMonitor.Shared.Results.Interfaces;

public interface IResult
{
    bool IsSuccessful { get; }
    string? Message { get; }
}