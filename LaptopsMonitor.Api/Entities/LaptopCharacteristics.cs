using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Entities;

public class LaptopCharacteristics : ILaptopCharacteristics
{
    public string Resolution { get; init; } = string.Empty;
    
    public string DisplayMatrix { get; init; } = string.Empty;
    
    public string DisplayRefreshRate { get; init; } = string.Empty;
    
    public string Cpu { get; init; } = string.Empty;
    
    public string Ram { get; init; } = string.Empty;
    
    public string Dd { get; init; } = string.Empty;
    
    public string Gpu { get; init; } = string.Empty;
    
    public string Color { get; init; } = string.Empty;
}