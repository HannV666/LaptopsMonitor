using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Domain.Options.Primitives;
using LaptopsMonitor.Infrastructure.Entities.Interfaces;
using LaptopsMonitor.Infrastructure.Options.Interfaces;
using LaptopsMonitor.Shared.Results.Interfaces;
using LaptopsMonitor.Shared.Results.Primitives;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LaptopsMonitor.Infrastructure.Repositories.Base;

public abstract class MongoRepository<TEntity>  : IRepository<TEntity>
    where TEntity : IMongoEntity
{
    private readonly IMongoCollection<TEntity> _collection;

    protected MongoRepository(IOptions<IMongoOptions<TEntity>> options, IMongoClient client)
    {
        var options1 = options.Value;
        _collection = client
            .GetDatabase(options1.DatabaseName)
            .GetCollection<TEntity>(options1.CollectionName);
    }

    public async Task<IEnumerableResult<TEntity>> GetAsync(PageOptions pageOptions, CancellationToken cancellationToken = default)
    {
        try
        {
            var totalCount = await _collection
                .AsQueryable()
                .CountAsync(cancellationToken);
        
            var query = _collection
                .AsQueryable()
                .Skip((pageOptions.Page - 1) * pageOptions.PageSize)
                .Take(pageOptions.PageSize);

            return new PagedResult<TEntity>
            {
                IsSuccessful = true,
                Page = pageOptions.Page,
                TotalPages = totalCount / pageOptions.PageSize,
                Data = await query.ToListAsync(cancellationToken)
            };
        }
        catch (Exception e)
        {
            return new PagedResult<TEntity>
            {
                IsSuccessful = false,
                Message = e.Message
            };
        }
    }

    public async Task<IResult> BulkInsertAsync(IEnumerable<TEntity> data, CancellationToken cancellationToken = default)
    {
        try
        {
            await _collection.InsertManyAsync(data, cancellationToken: cancellationToken);

            return new Result
            {
                IsSuccessful = true
            };
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