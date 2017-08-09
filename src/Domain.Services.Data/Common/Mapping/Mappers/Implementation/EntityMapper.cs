using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Mmu.Ddws.Domain.Services.Data.Common.Mapping.Mappers.Implementation
{
    public class EntityMapper : IMapper
    {
        public void InitializeMapping()
        {
            BsonClassMap.RegisterClassMap<Entity>(
                f =>
                {
                    f.MapIdMember(c => c.Id).SetIdGenerator(new StringObjectIdGenerator());
                });
        }
    }
}