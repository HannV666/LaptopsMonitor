using System.Text.Json.Serialization;

namespace LaptopsMonitor.Application.DataClients.Laptops.OnlinerResponses;

public class OnlinerLaptopPrice
{
    [JsonPropertyName("price_min")]
    public Price? MinPrice { get; init; }

    public class Price
    {
        [JsonPropertyName("amount")] public string Amount { get; init; } = "0";
    }
}