using Mmu.Ddws.Domain.Services.Data.Areas.Common.Repositories;
using Mmu.Ddws.Domain.Services.Data.Infrastructure.Mapping;
using Mmu.Ddws.Domain.Services.Data.Infrastructure.Mapping.Implementation;
using Mmu.Ddws.Domain.Services.Data.Infrastructure.Mapping.Mappers;
using Mmu.Ddws.Domain.Services.Data.Infrastructure.Repositories.Handlers;
using Mmu.Ddws.Domain.Services.Data.Infrastructure.Repositories.Handlers.Implementation;
using Mmu.Ddws.Domain.Services.Infrastructure.Repositories;
using StructureMap;

namespace Mmu.Ddws.Domain.Services.Data.Infrastructure.Ioc
{
    public class IocRegistry : Registry
    {
        public IocRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly(); // Scan this assembly
                    scan.AddAllTypesOf(typeof(IRepository<>));
                    scan.AddAllTypesOf(typeof(IMongoDbFilterDefinitionFactory<>));
                    scan.AddAllTypesOf<IMapper>();
                    scan.WithDefaultConventions();
                });

            For<IRepositoryFactory>().Use<RepositoryFactory>().Singleton();
            For<IMappingInitializationService>().Use<MappingInitializationService>().Singleton();
            For<IMongoClientFactory>().Use<MongoClientFactory>().Singleton();
        }
    }
}