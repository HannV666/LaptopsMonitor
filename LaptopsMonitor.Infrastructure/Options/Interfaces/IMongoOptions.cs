namespace LaptopsMonitor.Infrastructure.Options.Interfaces;

public interface IMongoOptions
{
    string ConnectionString { get; }
    string DatabaseName { get; }
    string CollectionName { get; }
}