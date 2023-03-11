using LaptopsMonitor.Shared.Results.Interfaces;

namespace LaptopsMonitor.Shared.Results.Primitives;

public class Result : IResult
{
    public bool IsSuccessful { get; init; }
    public string? Message { get; init; }
}