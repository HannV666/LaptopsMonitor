using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Application.Mappers;

public static class LaptopCharacteristicsMapper
{
    public static LaptopCharacteristics ToEntity(this ILaptopCharacteristics? laptopCharacteristics)
    {
        if (laptopCharacteristics is null)
        {
            throw new ArgumentNullException(nameof(laptopCharacteristics), "Mapping exception");
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