using MongoDB.Driver;

namespace Mmu.Ddws.Domain.Services.Infrastructure.Repositories.Handlers
{
    public interface IMongoClientFactory
    {
        MongoClient Create();
    }
}