using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;
using Mmu.Ddws.Domain.Services.Data.Infrastructure.Mapping.Mappers;
using MongoDB.Bson.Serialization;

namespace Mmu.Ddws.Domain.Services.Data.Common.Mappers
{
    public class AggregateRootMapper : IMapper
    {
        public void InitializeMapping()
        {
            BsonClassMap.RegisterClassMap<AggregateRoot>(
                f =>
                {
                    f.MapMember(c => c.AggregateTypeName);
                });
        }
    }
}