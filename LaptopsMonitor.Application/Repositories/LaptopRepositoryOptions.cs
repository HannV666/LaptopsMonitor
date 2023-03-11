using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Infrastructure.Options.Interfaces;

namespace LaptopsMonitor.Application.Repositories;

public class LaptopRepositoryOptions : IMongoOptions<Laptop>
{
    public required string DatabaseName { get; init; }
    
    public required string CollectionName { get; init; }
}