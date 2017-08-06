using Mmu.Ddws.Application.Common.Mapping;
using Mmu.Ddws.Domain.IndividualManagement.Models.AggregateRoots;
using Mmu.Ddws.Domain.IndividualManagement.Models.ValueObjects;
using Mmu.Ddws.Domain.Services.IndividualManagement.Factories;

namespace Mmu.Ddws.Application.IndividualManagement.Dtos.Mappers
{
    public class IndividualDtoMapper : IMapper<IndividualDto, Individual>
    {
        private readonly IIndividualFactory _individualFactory;
        private readonly IMappingService _mappingService;

        public IndividualDtoMapper(IIndividualFactory individualFactory, IMappingService mappingService)
        {
            _individualFactory = individualFactory;
            _mappingService = mappingService;
        }

        public Individual MapToDomainObject(IndividualDto dto)
        {
            var gender = _mappingService.MapToDomain<IndividualGenderDto, IndividualGender>(dto.Gender);
            var individual = _individualFactory.CreateIndividual(dto.FirstName, dto.LastName, gender);
            return individual;
        }

        public IndividualDto MapToDto(Individual domainObject)
        {
            return new IndividualDto
            {
                FirstName = domainObject.FirstName,
                Gender = _mappingService.MapToDto<IndividualGender, IndividualGenderDto>(domainObject.Gender),
                Id = domainObject.Id,
                LastName = domainObject.LastName
            };
        }
    }
}