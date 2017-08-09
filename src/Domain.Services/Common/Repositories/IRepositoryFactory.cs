using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;

namespace Mmu.Ddws.Domain.Services.Common.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>()
            where T : AggregateRoot;
    }
}