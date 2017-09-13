using Mmu.Ddws.Domain.Areas.Common.ModelAbstractions;

namespace Mmu.Ddws.Domain.Services.Infrastructure.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>()
            where T : AggregateRoot;
    }
}