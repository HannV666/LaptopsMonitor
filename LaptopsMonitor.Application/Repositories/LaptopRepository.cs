using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Infrastructure.Repositories.Base;
using LaptopsMonitor.Shared.Results.Interfaces;
using LaptopsMonitor.Shared.Results.Primitives;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LaptopsMonitor.Application.Repositories;

public class LaptopRepository : MongoRepository<Laptop>
{
    public LaptopRepository(IOptions<LaptopRepositoryOptions> options, IMongoClient client) 
        : base(options, client)
    { }

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
        
            return await base.BulkInsertAsync(newData, cancellationToken);
        }
        catch (Exception e)
        {
            return new Result
            {
                IsSuccessful = false,
                Message = e.Message
            };
        }
    }
}