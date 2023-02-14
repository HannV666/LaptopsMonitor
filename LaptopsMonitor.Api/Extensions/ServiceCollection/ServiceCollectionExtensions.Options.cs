using LaptopsMonitor.Infrastructure.Options;

namespace LaptopsMonitor.Api.Extensions.ServiceCollection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppOptions(this IServiceCollection services)
    {
        return services
            .AddOptions<HttpOptions>(HttpOptions.Key)
            .BindConfiguration(HttpOptions.Key)
            .Services
            .AddOptions<MongoOptions>(MongoOptions.Key)
            .BindConfiguration(MongoOptions.Key)
            .Services
            .AddOptions<RepositoryOptions>(RepositoryOptions.Key)
            .BindConfiguration(RepositoryOptions.Key)
            .Services;
    }
}
