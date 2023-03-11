using LaptopsMonitor.Application.DataClients.Laptops;
using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaskExtensions = LaptopsMonitor.Application.Extensions.TaskExtensions;

namespace LaptopsMonitor.Application.HostedServices.Monitoring;

public class MonitoringService : BackgroundService
{
    private readonly IDataClient<LaptopsParam, Laptop> _dataClient;
    private readonly IRepository<Laptop> _repository;
    private readonly MonitoringOptions _options;
    private readonly ILogger<MonitoringService> _logger;

    public MonitoringService(IDataClient<LaptopsParam, Laptop> dataClient,
        IRepository<Laptop> repository,
        IOptions<MonitoringOptions> options, 
        ILogger<MonitoringService> logger)
    {
        _dataClient = dataClient;
        _repository = repository;
        _options = options.Value;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Monitoring has started");
        
        int lastPage = 0;
        while (await TaskExtensions.WaitAsync(_options.ToTimeSpan(), stoppingToken))
        {
            var tasks = Enumerable.Range(1 + lastPage, 
                    _options.PagesToRead + lastPage)
                .Select(i => FetchAndSaveDataAsync(i, stoppingToken));

            await Task.WhenAll(tasks)
                .ConfigureAwait(false);

            lastPage += _options.PagesToRead;
        }
        
        _logger.LogInformation("Monitoring has ended");
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
            _logger.LogInformation("Laptops were fetched unsuccessfully {Message}", data.Message);
            return;
        }

        var result = await _repository.BulkInsertAsync(data.Data, cancellationToken)
            .ConfigureAwait(false);

        _logger.LogInformation("laptops were uploaded to mongo {Message}", result.Message);
    }
}