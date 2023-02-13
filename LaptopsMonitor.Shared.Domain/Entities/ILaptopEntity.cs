namespace LaptopsMonitor.Shared.Domain.Entities;

public interface ILaptopEntity
{
    string Name { get; }

    decimal Price { get; }

    DateTimeOffset ScanDate { get; }

    string ShortDescription { get; }
}
