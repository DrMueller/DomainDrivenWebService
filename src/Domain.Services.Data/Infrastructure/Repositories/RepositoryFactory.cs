using Mmu.Ddws.Domain.Areas.Common.ModelAbstractions;
using Mmu.Ddws.Domain.Services.Infrastructure.Repositories;
using StructureMap;

namespace Mmu.Ddws.Domain.Services.Data.Areas.Common.Repositories
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