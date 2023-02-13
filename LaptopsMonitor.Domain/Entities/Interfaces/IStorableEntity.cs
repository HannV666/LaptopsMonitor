namespace LaptopsMonitor.Domain.Entities.Interfaces;

public interface IStorableEntity<TKey>
{
    TKey Id { get; }
}
