using System.Text.Json;
using LaptopsMonitor.Dashboard.Application.ViewModels;
using LaptopsMonitor.Infrastructure.Clients.Base;
using LaptopsMonitor.Shared.Results.Interfaces;
using LaptopsMonitor.Shared.Results.Primitives;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LaptopsMonitor.Dashboard.Application.DataClients.Laptops;

public class LaptopDataClient : HttpDataClient<LaptopParam, LaptopViewModel>
{
    private readonly JsonSerializerOptions _jsonOptions;
    private ILogger<LaptopDataClient> _logger;

    public LaptopDataClient(IOptions<LaptopOptions> options, 
        HttpClient client, 
        JsonSerializerOptions jsonOptions,
        ILogger<LaptopDataClient> logger) 
        : base(options.Value, client, logger)
    {
        _jsonOptions = jsonOptions;
        _logger = logger;
    }

    protected override async Task<IEnumerableResult<LaptopViewModel>> HandleResponseAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        try
        {
            var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

            var result = await JsonSerializer.DeserializeAsync<PagedResult<LaptopViewModel>>(stream,
                _jsonOptions,
                cancellationToken);

            if (result is null)
            {
                return new EnumerableResult<LaptopViewModel>()
                {
                    IsSuccessful = false,
                    Message = "No result",
                    Data = Enumerable.Empty<LaptopViewModel>()
                };
            }

            return result;
        }
        catch (Exception e)
        { 
            _logger.LogError(e, "Exception occured while data fetching");

            return new EnumerableResult<LaptopViewModel>()
            {
                IsSuccessful = false,
                Message = e.Message
            };
        }
    }
}