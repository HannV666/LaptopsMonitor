using LaptopsMonitor.Api.Options;
using LaptopsMonitor.Infrastructure.Options;

namespace LaptopsMonitor.Api.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddOptions(this IServiceCollection services)
    {
        return services
            .AddOptions<HttpOptions>(HttpOptions.Key)
            .Services
            .AddOptions<MongoOptions>(MongoOptions.Key)
            .Services
            .AddOptions<RepositoryOptions>(RepositoryOptions.Key)
            .Services
            .AddOptions<EndPointOptions>(EndPointOptions.Key)
            .Services;
    }
}
