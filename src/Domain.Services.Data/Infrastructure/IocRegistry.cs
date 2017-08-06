using Mmu.Ddws.Domain.Services.Common.Repositories;
using Mmu.Ddws.Domain.Services.Infrastructure.Repositories.Handlers;
using StructureMap;

namespace Mmu.Ddws.Domain.Services.Infrastructure.Infrastructure
{
    public class IocRegistry : Registry
    {
        public IocRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly(); // Scan this assembly
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf(typeof(IRepository<>));
                    scan.AddAllTypesOf(typeof(IMongoDbFilterDefinitionFactory<>));
                });
        }
    }
}