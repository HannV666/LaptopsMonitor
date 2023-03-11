namespace LaptopsMonitor.Shared.Entities.Interfaces;

public interface ILaptopEntity<out TCharacteristics>
{
    string Name { get; }
    
    decimal Price { get; }
    
    TCharacteristics? Characteristics { get; }
}