using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Infrastructure.Repositories.Base;
using LaptopsMonitor.Shared.Results.Interfaces;
using LaptopsMonitor.Shared.Results.Primitives;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LaptopsMonitor.Application.Repositories;

public class LaptopRepository : MongoRepository<Laptop>
{
    private readonly ILogger<LaptopRepository> _logger;

    public LaptopRepository(IOptions<LaptopRepositoryOptions> options, 
        IMongoClient client, 
        ILogger<LaptopRepository> logger) 
        : base(options, client, logger)
    {
        _logger = logger;
    }

    public override async Task<IResult> BulkInsertAsync(IEnumerable<Laptop> data, CancellationToken cancellationToken = default)
    {
        try
        {
            var existingData = await Collection.AsQueryable()
                .Where(l => data.Any(d => d.Name == l.Name))
                .ToListAsync(cancellationToken);

            if (existingData.Count == 0)
            {
                return await base.BulkInsertAsync(data, cancellationToken);
            }

            var newData = data.ExceptBy(existingData.Select(e => e.Name), 
                l => l.Name, 
                StringComparer.InvariantCultureIgnoreCase);
        
            _logger.LogInformation("{Count} already existing items were passed", existingData.Count);
            
            return await base.BulkInsertAsync(newData, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Exception occured at insert data filtration");
            
            return new Result
            {
                IsSuccessful = false,
                Message = e.Message
            };
        }
    }
}