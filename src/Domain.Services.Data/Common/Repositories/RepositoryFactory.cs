using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;
using Mmu.Ddws.Domain.Services.Common.Repositories;
using StructureMap;

namespace Mmu.Ddws.Domain.Services.Data.Common.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IContainer _container;

        public RepositoryFactory(IContainer container)
        {
            _container = container;
        }

        public IRepository<T> CreateRepository<T>() where T : AggregateRoot
        {
            return _container.GetInstance<IRepository<T>>();
        }
    }
}