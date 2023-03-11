using LaptopsMonitor.Infrastructure.Entities.Base;
using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Application.Entities;

public class Laptop : MongoEntity, ILaptopEntity<LaptopCharacteristics>
{
    public required string Name { get; init; }

    public required decimal Price { get; init; }
    
    public required LaptopCharacteristics Characteristics { get; init; }
}