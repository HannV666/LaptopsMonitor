using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using LaptopsMonitor.DataClients.Laptops;
using LaptopsMonitor.Entities;
using LaptopsMonitor.Infrastructure.DependencyInjection;

namespace LaptopsMonitor.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSerializerJsonOptions(this IServiceCollection serviceCollection, 
        JsonSerializerOptions? options = default)
    {
        options ??= new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
        };
        
        return serviceCollection.AddSingleton(options);
    }
    
    public static IServiceCollection AddLaptopsDataClient(this IServiceCollection serviceCollection) 
        => serviceCollection.AddDataClient<LaptopOptions, LaptopsDataClient, LaptopsParam, Laptop>();
}