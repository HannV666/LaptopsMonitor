using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Infrastructure.Entities.Interfaces;
using MongoDB.Bson;

namespace LaptopsMonitor.Infrastructure.Interfaces;

public interface IMongoRepository<TMongoEnity> : IRepository<ObjectId, TMongoEnity>
    where TMongoEnity : class, IMongoEntity
{ }
