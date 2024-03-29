using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using LaptopsMonitor.Application.DataClients.Laptops;
using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Application.HostedServices.Monitoring;
using LaptopsMonitor.Application.Repositories;
using LaptopsMonitor.Infrastructure.DependencyInjection;

namespace LaptopsMonitor.Api.Extensions;

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

    public static IServiceCollection AddMonitoringService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddOptions<MonitoringOptions>()
            .BindConfiguration(nameof(MonitoringOptions));

        return serviceCollection.AddHostedService<MonitoringService>();
    }

    public static IServiceCollection DisallowCors(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(setup =>
        {
            setup.AddPolicy("DisallowCors", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(o => true);
            });
        });

        return serviceCollection;
    }
    
    public static IServiceCollection AddLaptopsDataClient(this IServiceCollection serviceCollection) 
        => serviceCollection.AddDataClient<LaptopOptions, LaptopsDataClient, LaptopsParam, Laptop>();

    public static IServiceCollection AddLaptopRepository(this IServiceCollection serviceCollection)
        => serviceCollection.AddMongoRepository<LaptopRepository, LaptopRepositoryOptions, Laptop>();
}