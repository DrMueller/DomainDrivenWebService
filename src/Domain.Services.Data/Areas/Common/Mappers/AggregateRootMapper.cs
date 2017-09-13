using Mmu.Ddws.Domain.Areas.Common.ModelAbstractions;
using Mmu.Ddws.Domain.Services.Data.Infrastructure.Mapping.Mappers;
using MongoDB.Bson.Serialization;

namespace Mmu.Ddws.Domain.Services.Data.Areas.Common.Mappers
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