using System.Text.Json;
using LaptopsMonitor.Application.DataClients.Laptops.OnlinerResponses;
using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Application.Mappers;
using LaptopsMonitor.Infrastructure.Clients.Base;
using LaptopsMonitor.Shared.Results.Interfaces;
using LaptopsMonitor.Shared.Results.Primitives;
using Microsoft.Extensions.Options;

namespace LaptopsMonitor.Application.DataClients.Laptops;

public class LaptopsDataClient : HttpDataClient<LaptopsParam, Laptop>
{
    private readonly JsonSerializerOptions _options;

    public LaptopsDataClient(IOptions<LaptopOptions> options,
        HttpClient client,
        JsonSerializerOptions options1)
        : base(options.Value, client)
    {
        _options = options1;
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
                    options: _options,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (onlinerResponse is null)
            {
                return new EnumerableResult<Laptop>
                {
                    IsSuccessful = false,
                    Message = "Empty response from onliner"
                };
            }

            var data = onlinerResponse.Products
                .Select(p => p.ToEntity());

            return new EnumerableResult<Laptop>
            {
                IsSuccessful = true,
                Data = data
            };
        }
        catch (Exception e)
        {
            return new EnumerableResult<Laptop>
            {
                IsSuccessful = false,
                Message = e.Message
            };
        }
    }
}