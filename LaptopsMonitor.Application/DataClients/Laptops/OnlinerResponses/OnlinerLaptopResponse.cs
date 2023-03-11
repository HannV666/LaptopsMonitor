using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Application.DataClients.Laptops.OnlinerResponses;

public class OnlinerLaptopResponse : ILaptopEntity<OnlinerLaptopCharacteristics>
{
    public string Name { get; init; } = string.Empty;

    public decimal Price => decimal.Parse(Prices?.MinPrice?.Amount ?? "0");

    public OnlinerLaptopCharacteristics Characteristics => new()
    {
        Description = Description
    };

    public OnlinerLaptopPrice? Prices { get; init; }

    public string Description { get; init; } = string.Empty;
}