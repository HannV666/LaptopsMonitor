using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Application.Mappers;

public static class LaptopMapper
{
    public static Laptop ToEntity(this ILaptopEntity? entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity), "Mapping exception");
        }
        
        return new Laptop
        {
            Name = entity.Name,
            Price = entity.Price,
            Characteristics = entity.Characteristics.ToEntity()
        };
    }
}