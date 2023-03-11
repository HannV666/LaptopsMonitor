using LaptopsMonitor.Infrastructure.Entities.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LaptopsMonitor.Infrastructure.Entities.Base;

public abstract class MongoEntity : IMongoEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public ObjectId Id { get; init; }

    public DateTimeOffset CreationDate { get; } = DateTimeOffset.UtcNow;
}