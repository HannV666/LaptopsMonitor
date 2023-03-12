namespace LaptopsMonitor.Dashboard.Application.DataClients.Laptops;

public class LaptopParam
{
    public required int Page { get; init; }
    
    public int PageSize { get; init; }
    
    public string? Filter { get; init; } 
}