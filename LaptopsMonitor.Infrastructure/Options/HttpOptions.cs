namespace LaptopsMonitor.Infrastructure.Options;

public class HttpOptions
{
    public const string Key = nameof(HttpOptions);

    public string BaseAddress { get; init; } = string.Empty;

    public string CategoryName { get; init; } = string.Empty;

    public string QueryParam { get; init; } = string.Empty;

    public int PagesToRead { get; init; }
}
