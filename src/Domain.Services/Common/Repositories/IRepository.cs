using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;
using Mmu.Ddws.Domain.Infrastructure.Specifications;

namespace Mmu.Ddws.Domain.Services.Common.Repositories
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<T>> LoadAllAsync();

        Task<IReadOnlyCollection<T>> LoadAsync(ISpecification<T> specification);

        Task<T> LoadByIdAsync(string id);

        Task<T> SaveAsync(T aggregateRoot);
    }
}