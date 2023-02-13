using LaptopsMonitor.Infrastructure.Entities.Interfaces;
using LaptopsMonitor.Shared.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LaptopsMonitor.Infrastructure.Entities;

public class Laptop : IMongoEntity, ILaptopEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public ObjectId Id { get; init; }
    
    public string Name { get; init; } = string.Empty;
    
    public decimal Price { get; init; }
    
    public DateTimeOffset ScanDate { get; init; } = DateTimeOffset.UtcNow;

    public string ShortDescription { get; init; } = string.Empty;
}
