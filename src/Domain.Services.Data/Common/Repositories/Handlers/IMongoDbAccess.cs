using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Ddws.Domain.Services.Data.Common.Repositories.Handlers
{
    public interface IMongoDbAccess
    {
        IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot;
    }
}