using LaptopsMonitor.Api.Options;
using Microsoft.Extensions.Options;

namespace LaptopsMonitor.Api.Extensions;

public static class EndPointsExtentions
{
    public static WebApplication XmlEndPoint(this WebApplication application, IConfiguration configuration)
    {
        var endpointOptions 
            = application
            .Services
            .GetRequiredService<IOptionsFactory<EndPointOptions>>()
            .Create(EndPointOptions.Key);

        return application;
    }
}
