using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Infrastructure.Options;
using LaptopsMonitor.Shared.Domain.Results;
using Microsoft.Extensions.Options;
using System.Xml;

namespace LaptopsMonitor.Infrastructure;

public class LaptopsXmlProvider : IXmlProvider<int>
{
    private readonly HttpClient _client;
    private readonly HttpOptions _options;

    public LaptopsXmlProvider(HttpClient client, IOptionsFactory<HttpOptions> optionsFactory)
    {
        _client = client;
        _options = optionsFactory.Create(HttpOptions.Key);
    }

    public async Task<XmlResult> GetAsync(int page, CancellationToken cancellationToken = default)
    {
        var url = $"{_options.BaseAddress}/{_options.CategoryName}?{_options.QueryParam}={page}";

        var response = await _client.GetStringAsync(url, cancellationToken);

        var document = new XmlDocument();
        //document.Load(response);

        return new XmlResult
        {
            IsSuccess = true,
            Data = document
        };
    }
}
