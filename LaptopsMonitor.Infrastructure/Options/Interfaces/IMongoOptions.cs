using LaptopsMonitor.Infrastructure.Entities.Interfaces;

namespace LaptopsMonitor.Infrastructure.Options.Interfaces;

public interface IMongoOptions<TEntity>
    where TEntity : IMongoEntity
{
    string DatabaseName { get; }
    string CollectionName { get; }
}