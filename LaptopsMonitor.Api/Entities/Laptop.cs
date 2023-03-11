using LaptopsMonitor.Infrastructure.Entities.Base;
using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Entities;

public class Laptop : MongoEntity, ILaptopEntity
{
    public string Name { get; init; } = string.Empty;

    public decimal Price { get; init; }
    
    public ILaptopCharacteristics? Characteristics { get; init; }
}