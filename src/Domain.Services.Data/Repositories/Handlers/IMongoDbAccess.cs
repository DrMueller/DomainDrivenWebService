using Mmu.Ddws.Domain.Common.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Ddws.Domain.Services.Infrastructure.Repositories.Handlers
{
    public interface IMongoDbAccess
    {
        IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot;
    }
}