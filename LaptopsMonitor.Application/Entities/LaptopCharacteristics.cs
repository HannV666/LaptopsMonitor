using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Application.Entities;

public class LaptopCharacteristics : ILaptopCharacteristics
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
}