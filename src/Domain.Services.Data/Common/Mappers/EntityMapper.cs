using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;
using Mmu.Ddws.Domain.Services.Data.Infrastructure.Mapping.Mappers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Mmu.Ddws.Domain.Services.Data.Common.Mappers
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