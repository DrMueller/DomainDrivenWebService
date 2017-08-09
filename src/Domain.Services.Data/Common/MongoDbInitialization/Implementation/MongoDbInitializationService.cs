using Mmu.Ddws.Domain.Services.Data.Common.Mapping;
using Mmu.Ddws.Domain.Services.Data.Common.Serialization;
using MongoDB.Bson.Serialization;

namespace Mmu.Ddws.Domain.Services.Data.Common.MongoDbInitialization.Implementation
{
    public class MongoDbInitializationService : IMongoDbInitializationService
    {
        private readonly IMappingInitializationService _mappingInitializationService;

        public MongoDbInitializationService(IMappingInitializationService mappingInitializationService)
        {
            _mappingInitializationService = mappingInitializationService;
        }

        public void AssureEverythingIsInitialized()
        {
            _mappingInitializationService.AssureMappinsgAreInitialized();
            BsonSerializer.RegisterSerializationProvider(new SerializationProvider());
        }
    }
}