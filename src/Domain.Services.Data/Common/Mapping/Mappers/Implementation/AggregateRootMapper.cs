using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;
using MongoDB.Bson.Serialization;

namespace Mmu.Ddws.Domain.Services.Data.Common.Mapping.Mappers.Implementation
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