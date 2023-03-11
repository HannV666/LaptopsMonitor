namespace LaptopsMonitor.Infrastructure.Entities.Interfaces;

public interface IEntity<out TKey>
{
    TKey Id { get; }
    
    DateTimeOffset CreationDate { get; }
}