using Mmu.Ddws.Domain.Areas.Common.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Ddws.Domain.Services.Data.Infrastructure.Repositories.Handlers
{
    public interface IMongoDbAccess
    {
        IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot;
    }
}