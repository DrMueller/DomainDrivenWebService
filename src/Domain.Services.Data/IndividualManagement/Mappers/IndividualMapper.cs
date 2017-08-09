using Mmu.Ddws.Domain.IndividualManagement.Models.AggregateRoots;
using Mmu.Ddws.Domain.Services.Data.Common.Mapping.Mappers;
using MongoDB.Bson.Serialization;

namespace Mmu.Ddws.Domain.Services.Data.IndividualManagement.Mappers
{
    public class IndividualMapper : IMapper
    {
        public void InitializeMapping()
        {
            BsonClassMap.RegisterClassMap<Individual>(
                f =>
                {
                    f.MapMember(c => c.Addresses);
                    f.MapMember(c => c.Gender);
                    f.MapMember(c => c.LastName);
                    f.MapMember(c => c.BirthDate);
                    f.MapMember(c => c.FirstName);
                    f.SetIgnoreExtraElements(true);
                });
        }
    }
}