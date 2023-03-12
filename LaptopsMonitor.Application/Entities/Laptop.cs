using System.Linq.Expressions;
using LaptopsMonitor.Infrastructure.Entities.Base;
using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Application.Entities;

public class Laptop : MongoEntity, ILaptopEntity<LaptopCharacteristics>
{
    public required string Name { get; init; }

    public required decimal Price { get; init; }

    public required LaptopCharacteristics Characteristics { get; init; }

    public static Expression<Func<Laptop, bool>> IsMatch(string filter)
        => l => l.Name.Contains(filter) ||
                l.Characteristics.Resolution.Contains(filter) ||
                l.Characteristics.DisplayMatrix.Contains(filter) ||
                l.Characteristics.DisplayRefreshRate.Contains(filter) ||
                l.Characteristics.Cpu.Contains(filter) ||
                l.Characteristics.Ram.Contains(filter) ||
                l.Characteristics.Dd.Contains(filter) ||
                l.Characteristics.Gpu.Contains(filter) ||
                l.Characteristics.Os.Contains(filter) ||
                l.Characteristics.Color.Contains(filter);
}