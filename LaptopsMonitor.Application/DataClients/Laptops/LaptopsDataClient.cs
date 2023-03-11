using System.Text.Json;
using LaptopsMonitor.Application.DataClients.Laptops.OnlinerResponses;
using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Application.Mappers;
using LaptopsMonitor.Infrastructure.Clients.Base;
using LaptopsMonitor.Shared.Results.Interfaces;
using LaptopsMonitor.Shared.Results.Primitives;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LaptopsMonitor.Application.DataClients.Laptops;

public class LaptopsDataClient : HttpDataClient<LaptopsParam, Laptop>
{
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly ILogger<LaptopsDataClient> _logger;

    public LaptopsDataClient(IOptions<LaptopOptions> options,
        HttpClient client,
        JsonSerializerOptions jsonOptions, 
        ILogger<LaptopsDataClient> logger)
        : base(options.Value, client, logger)
    {
        _jsonOptions = jsonOptions;
        _logger = logger;
    }

    protected override async Task<IEnumerableResult<Laptop>> HandleResponseAsync(HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        try
        {
            var stream = await response.Content
                .ReadAsStreamAsync(cancellationToken)
                .ConfigureAwait(false);

            var onlinerResponse = await JsonSerializer.DeserializeAsync<OnlinerResponse>(utf8Json: stream,
                    options: _jsonOptions,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (onlinerResponse is null)
            {
                _logger.LogInformation("Empty response from onliner");
                
                return new EnumerableResult<Laptop>
                {
                    IsSuccessful = false,
                    Message = "Empty response from onliner"
                };
            }

            var data = onlinerResponse.Products
                .Select(p => p.ToEntity());

            _logger.LogInformation("Data parsed");
            
            return new EnumerableResult<Laptop>
            {
                IsSuccessful = true,
                Data = data
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Exception while data parsing");
            
            return new EnumerableResult<Laptop>
            {
                IsSuccessful = false,
                Message = e.Message
            };
        }
    }
}