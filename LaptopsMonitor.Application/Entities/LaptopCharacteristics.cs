using LaptopsMonitor.Infrastructure.Entities.Base;
using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Application.Entities;

public class LaptopCharacteristics : MongoEntity, ILaptopCharacteristics
{
    public required string Resolution { get; init; }
    
    public required string DisplayMatrix { get; init; }
    
    public required string DisplayRefreshRate { get; init; }
    
    public required string Cpu { get; init; }
    
    public required string Ram { get; init; }
    
    public required string Dd { get; init; }
    
    public required string Gpu { get; init; }

    public required string Os { get; init; }
    
    public required string Color { get; init; }

    public static bool IsMatch(LaptopCharacteristics laptopCharacteristics, string filter)
        => laptopCharacteristics.Resolution.Contains(filter) ||
           laptopCharacteristics.DisplayMatrix.Contains(filter) ||
           laptopCharacteristics.DisplayRefreshRate.Contains(filter) ||
           laptopCharacteristics.Cpu.Contains(filter) ||
           laptopCharacteristics.Ram.Contains(filter) ||
           laptopCharacteristics.Dd.Contains(filter) ||
           laptopCharacteristics.Gpu.Contains(filter) ||
           laptopCharacteristics.Os.Contains(filter) ||
           laptopCharacteristics.Color.Contains(filter);
}