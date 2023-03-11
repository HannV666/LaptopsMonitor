using MongoDB.Bson;

namespace LaptopsMonitor.Infrastructure.Entities.Interfaces;

public interface IMongoEntity : IEntity<ObjectId>
{ }