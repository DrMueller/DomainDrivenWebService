using System.Collections.Generic;
using System.Linq;
using Mmu.Ddws.Application.Common.DtoMapping;
using Mmu.Ddws.Domain.IndividualManagement.Models.ValueObjects;

namespace Mmu.Ddws.Application.IndividualManagement.Dtos.Mappers
{
    public class IndividualGenderDtoMapper : IDtoMapper<IndividualGenderDto, IndividualGender>
    {
        private readonly IDictionary<IndividualGenderDto, IndividualGender> _map = new Dictionary<IndividualGenderDto, IndividualGender>
        {
            { IndividualGenderDto.Male, IndividualGender.Male },
            { IndividualGenderDto.Female, IndividualGender.Female }
        };

        public IndividualGender MapToDomainObject(IndividualGenderDto dto)
        {
            return _map[dto];
        }

        public IndividualGenderDto MapToDto(IndividualGender domainObject)
        {
            return _map.First(f => f.Value == domainObject).Key;
        }
    }
}