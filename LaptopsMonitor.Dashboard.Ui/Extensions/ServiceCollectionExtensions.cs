using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using LaptopsMonitor.Dashboard.Application.DataClients.Laptops;
using LaptopsMonitor.Dashboard.Application.ViewModels;
using LaptopsMonitor.Infrastructure.DependencyInjection;

namespace LaptopsMonitor.Dashboard.Extensions;

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
    
    public static IServiceCollection AddLaptopDataClient(this IServiceCollection serviceCollection)
        => serviceCollection.AddDataClient<LaptopOptions, LaptopDataClient, LaptopParam, LaptopViewModel>();
}