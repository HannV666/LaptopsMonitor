using LaptopsMonitor.Infrastructure.Options.Interfaces;

namespace LaptopsMonitor.Dashboard.Application.DataClients.Laptops;

public class LaptopOptions : IClientOptions<LaptopParam>
{
    public required string Route { get; init; }
    
    public string BuildRoute(LaptopParam @in)
    {
        return $"{Route}/{@in.Page}?pageSize={@in.PageSize}";
    }
}