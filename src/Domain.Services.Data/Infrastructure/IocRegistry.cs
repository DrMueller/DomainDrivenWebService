using System.Reflection;
using Mmu.Ddws.Domain.Services.Common.Repositories;
using Mmu.Ddws.Domain.Services.Data.Common.Mapping;
using Mmu.Ddws.Domain.Services.Data.Common.Mapping.Implementation;
using Mmu.Ddws.Domain.Services.Data.Common.Mapping.Mappers;
using Mmu.Ddws.Domain.Services.Data.Common.Repositories;
using Mmu.Ddws.Domain.Services.Data.Common.Repositories.Handlers;
using Mmu.Ddws.Domain.Services.Data.Common.Repositories.Handlers.Implementation;
using StructureMap;

namespace Mmu.Ddws.Domain.Services.Data.Infrastructure
{
    public class IocRegistry : Registry
    {
        public IocRegistry()
        {
            Scan(
                scan =>
                {
                    scan.Assembly(typeof(IocRegistry).GetTypeInfo().Assembly);

                    //scan.TheCallingAssembly(); // Scan this assembly
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