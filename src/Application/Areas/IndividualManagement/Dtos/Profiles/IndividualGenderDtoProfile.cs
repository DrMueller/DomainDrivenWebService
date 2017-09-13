using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mmu.Ddws.Domain.Areas.IndividualManagement.Models;

namespace Mmu.Ddws.Application.Areas.IndividualManagement.Dtos.Profiles
{
    public class IndividualGenderDtoProfile : Profile
    {
        private readonly IDictionary<IndividualGenderDto, IndividualGender> _map = new Dictionary<IndividualGenderDto, IndividualGender>
        {
            { IndividualGenderDto.Male, IndividualGender.Male },
            { IndividualGenderDto.Female, IndividualGender.Female }
        };

        public IndividualGenderDtoProfile()
        {
            CreateMap<IndividualGender, IndividualGenderDto>().ConvertUsing(
                gender =>
                {
                    return _map.First(f => f.Value == gender).Key;
                });

            CreateMap<IndividualGenderDto, IndividualGender>().ConvertUsing(dto => _map[dto]);
        }
    }
}