using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Infrastructure.Options.Interfaces;
using LaptopsMonitor.Shared.Results.Interfaces;
using LaptopsMonitor.Shared.Results.Primitives;
using Microsoft.Extensions.Logging;

namespace LaptopsMonitor.Infrastructure.Clients.Base;

public abstract class HttpDataClient<TIn, TOut> : IDataClient<TIn, TOut>
{
    private readonly IClientOptions<TIn> _options;
    private readonly HttpClient _client;
    private readonly ILogger<HttpDataClient<TIn, TOut>> _logger;

    protected HttpDataClient(IClientOptions<TIn> options, 
        HttpClient client, 
        ILogger<HttpDataClient<TIn, TOut>> logger)
    {
        _options = options;
        _client = client;
        _logger = logger;
    }

    public async Task<IEnumerableResult<TOut>> GetAsync(TIn @in, CancellationToken cancellationToken = default)
    {
        try
        {
            var uri = new Uri(_options.BuildRoute(@in), UriKind.Absolute);
            using var response = await _client.GetAsync(uri, cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Onliner returned: {StatusCode}", response.StatusCode);
                
                return new EnumerableResult<TOut>
                {
                    IsSuccessful = false,
                    Message = await response.Content.ReadAsStringAsync(cancellationToken)
                };
            }
            
            _logger.LogInformation("Start to parse data for request : {Uri}", uri);
            
            return await HandleResponseAsync(response, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception e)
        {
            return new EnumerableResult<TOut>
            {
                IsSuccessful = false,
                Message = e.Message
            };
        }
    }

    protected abstract Task<IEnumerableResult<TOut>> HandleResponseAsync(HttpResponseMessage response, CancellationToken cancellationToken);

    public void Dispose()
    {
        _client.Dispose();
    }
}