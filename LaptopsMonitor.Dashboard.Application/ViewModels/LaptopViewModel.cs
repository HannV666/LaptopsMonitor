using LaptopsMonitor.Shared.Entities.Interfaces;
using Microsoft.AspNetCore.Components;

namespace LaptopsMonitor.Dashboard.Application.ViewModels;

public class LaptopViewModel : ComponentBase, ILaptopEntity<LaptopCharacteristicsViewModel>
{
    public required string Name { get; init; }
    
    public required decimal Price { get; init; }
    
    public required DateTimeOffset CreationDate { get; init; }
    
    public required LaptopCharacteristicsViewModel Characteristics { get; init; }

    public string GetDescription()
    {
        string[] @params =
        {
            Characteristics.Resolution,
            Characteristics.DisplayMatrix,
            Characteristics.DisplayRefreshRate,
            Characteristics.Cpu,
            Characteristics.Gpu,
            Characteristics.Dd,
            Characteristics.Ram,
            Characteristics.Os,
            Characteristics.Color
        };

        return string.Join(", ", @params);
    }
}