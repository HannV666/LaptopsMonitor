using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Infrastructure.Options.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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
}