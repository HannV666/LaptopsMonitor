using LaptopsMonitor.Application.DataClients.Laptops;
using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TaskExtensions = LaptopsMonitor.Application.Extensions.TaskExtensions;

namespace LaptopsMonitor.Application.HostedServices.Monitoring;

public class MonitoringService : BackgroundService
{
    private readonly IDataClient<LaptopsParam, Laptop> _dataClient;
    private readonly IRepository<Laptop> _repository;
    private readonly MonitoringOptions _options;

    public MonitoringService(IDataClient<LaptopsParam, Laptop> dataClient,
        IRepository<Laptop> repository,
        IOptions<MonitoringOptions> options)
    {
        _dataClient = dataClient;
        _repository = repository;
        _options = options.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await TaskExtensions.WaitAsync(_options.ToTimeSpan(), stoppingToken))
        {
            var tasks = Enumerable.Range(1, _options.PagesToRead)
                .Select(i => FetchAndSaveDataAsync(i, stoppingToken));

            await Task.WhenAll(tasks);
        }
    }

    private async Task FetchAndSaveDataAsync(int page, CancellationToken cancellationToken)
    {
        var data = await _dataClient.GetAsync(new LaptopsParam
        {
            Page = page
        }, cancellationToken).ConfigureAwait(false);

        if (!data.IsSuccessful ||
            data.Data is null)
        {
            return;
        }

        var result = await _repository.BulkInsertAsync(data.Data, cancellationToken);

        if (!result.IsSuccessful)
        {
            // log
        }
    }
}