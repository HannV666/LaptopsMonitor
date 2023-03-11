using LaptopsMonitor.Entities;
using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Mappers;

public static class LaptopMapper
{
    public static Laptop? ToEntity(this ILaptopEntity? entity)
    {
        if (entity is null)
        {
            return default;
        }
        
        return new Laptop
        {
            Name = entity.Name,
            Price = entity.Price,
            Characteristics = entity.Characteristics.ToEntity()
        };
    }
}