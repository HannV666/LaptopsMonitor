using LaptopsMonitor.Entities;
using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Mappers;

public static class LaptopCharacteristicsMapper
{
    public static LaptopCharacteristics? ToEntity(this ILaptopCharacteristics? laptopCharacteristics)
    {
        if (laptopCharacteristics is null)
        {
            return default;
        }
        
        return new LaptopCharacteristics
        {
            Resolution = laptopCharacteristics.Resolution,
            DisplayMatrix = laptopCharacteristics.DisplayMatrix,
            Color = laptopCharacteristics.Color,
            Cpu = laptopCharacteristics.Cpu,
            Dd = laptopCharacteristics.Dd,
            DisplayRefreshRate = laptopCharacteristics.DisplayRefreshRate,
            Gpu = laptopCharacteristics.Gpu,
            Ram = laptopCharacteristics.Ram
        };
    }
}