namespace LaptopsMonitor.Infrastructure.Options;

public class RepositoryOptions
{
    public const string Key = nameof(RepositoryOptions);

    public string DatabaseName { get; init; } = string.Empty;

    public string CollectionName { get; set; } = string.Empty;

    public int PageSize { get; init; }
}
