namespace LaptopsMonitor.Infrastructure.Options;

public class MongoOptions
{
    public const string Key = nameof(MongoOptions);

    public string ConnectionString { get; init; } = string.Empty;
}
