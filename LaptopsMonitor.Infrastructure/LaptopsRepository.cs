using LaptopsMonitor.Infrastructure.Entities;
using LaptopsMonitor.Infrastructure.Interfaces;
using LaptopsMonitor.Infrastructure.Options;
using LaptopsMonitor.Shared.Domain.Results;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LaptopsMonitor.Infrastructure;

public class LaptopsRepository : IMongoRepository<Laptop>
{
    private readonly IMongoCollection<Laptop> _collection;
    private readonly RepositoryOptions _options;

    public LaptopsRepository(IMongoClient client, IOptionsFactory<RepositoryOptions> options)
    {
        _options = options.Create(RepositoryOptions.Key);
        _collection = client.GetDatabase(_options.DatabaseName)
            .GetCollection<Laptop>(_options.CollectionName);
    }
    
    public async Task<PagedResult<Laptop>> GetAsync(int page, CancellationToken cancellationToken = default)
    {
        try
        {
            var laptopQueryable = _collection.AsQueryable();

            var totalCount = await laptopQueryable.CountAsync(cancellationToken);
            var totalPages = totalCount / _options.PageSize;

            if (page > totalCount / _options.PageSize)
            {
                return new PagedResult<Laptop>
                {
                    IsSuccess = false,
                    Message = $"Max page is {totalPages}"
                };
            }

            var collection = await _collection.AsQueryable()
                .Skip((page - 1) * _options.PageSize)
                .Take(_options.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Laptop>
            {
                CurrentPage = page,
                TotalPages = totalCount,
                Data = collection,
                IsSuccess = true
            };
        }
        catch (Exception exception)
        {
            return new PagedResult<Laptop>
            {
                IsSuccess = false,
                Message = exception.Message
            };
        }
    }

    public async Task<EmptyResult> AddRangeAsync(IEnumerable<Laptop> entities, CancellationToken cancellationToken = default)
    {
        try
        {
            await _collection.InsertManyAsync(entities, cancellationToken: cancellationToken);

            return new EmptyResult
            {
                IsSuccess = true
            };
        }
        catch(Exception exception)
        {
            return new EmptyResult
            { 
                IsSuccess = false,
                Message = exception.Message,
            };
        }
    }
}
