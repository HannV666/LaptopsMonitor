using LaptopsMonitor.Domain.Entities.Interfaces;
using MongoDB.Bson;

namespace LaptopsMonitor.Infrastructure.Entities.Interfaces;

public interface IMongoEntity : IStorableEntity<ObjectId>
{ }
