using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.Application.DataClients.Laptops.OnlinerResponses;

public class OnlinerLaptopResponse : ILaptopEntity
{
    public string Name { get; init; } = string.Empty;

    public decimal Price => decimal.Parse(Prices?.MinPrice?.Amount ?? "0");

    public ILaptopCharacteristics Characteristics => new OnlinerLaptopCharacteristics
    {
        Description = Description
    };

    public OnlinerLaptopPrice? Prices { get; init; }

    public string Description { get; init; } = string.Empty;
}