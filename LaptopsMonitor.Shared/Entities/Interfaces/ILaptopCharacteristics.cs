namespace LaptopsMonitor.Shared.Entities.Interfaces;

public interface ILaptopCharacteristics
{
    public string Resolution { get; }
    
    public string DisplayMatrix { get; }
    
    public string DisplayRefreshRate { get; }
    
    public string Cpu { get; }

    public string Ram { get; }
    
    public string Dd { get; }
    
    public string Gpu { get; }
    
    public string Color { get; }
}