using LaptopsMonitor.Infrastructure.Options.Interfaces;

namespace LaptopsMonitor.Application.DataClients.Laptops;

public class LaptopOptions : IClientOptions<LaptopsParam>
{
    public string? Route { get; init; }
    
    public string BuildRoute(LaptopsParam @in)
    {
        return $"{Route}?page={@in.Page}";
    }
}