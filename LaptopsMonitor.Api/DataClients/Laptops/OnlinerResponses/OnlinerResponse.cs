namespace LaptopsMonitor.DataClients.Laptops.OnlinerResponses;

public class OnlinerResponse
{
    public IEnumerable<OnlinerLaptopResponse> Products { get; init; } 
        = Enumerable.Empty<OnlinerLaptopResponse>();
}