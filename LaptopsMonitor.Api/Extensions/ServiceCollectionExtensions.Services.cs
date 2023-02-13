using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Infrastructure;
using LaptopsMonitor.Infrastructure.Entities;
using LaptopsMonitor.Infrastructure.Interfaces;
using LaptopsMonitor.Infrastructure.Options;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LaptopsMonitor.Api.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddLaptopXmlProvider(this IServiceCollection services)
    {
        return services.AddHttpClient<IXmlProvider<int>, LaptopsXmlProvider>()
            .Services;
    }

    public static IServiceCollection AddLaptopRepository(this IServiceCollection services)
    {
        return services.AddScoped<IRepository<ObjectId, Laptop>, LaptopsRepository>()
            .AddScoped<IMongoRepository<Laptop>, LaptopsRepository>();
    }

    public static IServiceCollection AddMongoConneciton(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddSingleton<IMongoClient>(sp =>
        {
            var mongoOptions = sp.GetRequiredService<IOptionsFactory<MongoOptions>>().Create(MongoOptions.Key);

            return new MongoClient(mongoOptions.ConnectionString);
        });
    }
}
