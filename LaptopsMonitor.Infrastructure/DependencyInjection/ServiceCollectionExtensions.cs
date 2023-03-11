using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Infrastructure.Entities.Interfaces;
using LaptopsMonitor.Infrastructure.Options.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace LaptopsMonitor.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataClient<TOptions, TClient, TIn, TOut>(this IServiceCollection services)
        where TClient : class, IDataClient<TIn, TOut>
        where TOptions : class, IClientOptions<TIn>
    {
        var sectionName = typeof(TOptions).Name;
        services.AddOptions<TOptions>()
            .BindConfiguration(sectionName);

        services.AddHttpClient<IDataClient<TIn, TOut>, TClient>();

        return services;
    }

    public static IServiceCollection AddMongoClient(this IServiceCollection services, 
        Action<MongoClientSettings> configureSettings)
    {
        var settings = new MongoClientSettings();
        configureSettings(settings);
        
        var client = new MongoClient(settings);

        return services.AddSingleton<IMongoClient>(client);
    }
    
    public static IServiceCollection AddMongoRepository<TRepository, TOptions, TEntity>(this IServiceCollection services)
        where TRepository : class, IRepository<TEntity>
        where TOptions : class, IMongoOptions<TEntity>
        where TEntity : IMongoEntity
    {
        services.AddOptions<TOptions>()
            .BindConfiguration(typeof(TOptions).Name);
        
        services.AddTransient<IRepository<TEntity>, TRepository>();
        
        return services;
    }
}