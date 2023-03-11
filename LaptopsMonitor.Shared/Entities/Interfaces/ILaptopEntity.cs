namespace LaptopsMonitor.Shared.Entities.Interfaces;

public interface ILaptopEntity
{
    string Name { get; }
    
    decimal Price { get; }
    
    ILaptopCharacteristics? Characteristics { get; }
}