using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Infrastructure.Options.Interfaces;
using LaptopsMonitor.Shared.Results.Interfaces;
using LaptopsMonitor.Shared.Results.Primitives;

namespace LaptopsMonitor.Infrastructure.Clients.Base;

public abstract class HttpDataClient<TIn, TOut> : IDataClient<TIn, TOut>
{
    private readonly IClientOptions<TIn> _options;
    private readonly HttpClient _client;

    protected HttpDataClient(IClientOptions<TIn> options, HttpClient client)
    {
        _options = options;
        _client = client;
    }

    public async Task<IEnumerableResult<TOut>> GetAsync(TIn @in, CancellationToken cancellationToken = default)
    {
        try
        {
            var uri = new Uri(_options.BuildRoute(@in), UriKind.Absolute);
            using var response = await _client.GetAsync(uri, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return new EnumerableResult<TOut>
                {
                    IsSuccessful = false,
                    Message = await response.Content.ReadAsStringAsync(cancellationToken)
                };
            }

            return await HandleResponseAsync(response, cancellationToken);
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
}