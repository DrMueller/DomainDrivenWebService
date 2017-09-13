using MongoDB.Driver;

namespace Mmu.Ddws.Domain.Services.Data.Infrastructure.Repositories.Handlers
{
    public interface IMongoClientFactory
    {
        MongoClient Create();
    }
}