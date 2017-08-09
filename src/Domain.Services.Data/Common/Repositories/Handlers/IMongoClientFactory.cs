using MongoDB.Driver;

namespace Mmu.Ddws.Domain.Services.Data.Common.Repositories.Handlers
{
    public interface IMongoClientFactory
    {
        MongoClient Create();
    }
}