using AutoMapper;
using Mmu.Ddws.Common.ServiceProvisioning;
using Mmu.Ddws.Domain.IndividualManagement.Models;
using Mmu.Ddws.Domain.Services.IndividualManagement.Factories;

namespace Mmu.Ddws.Application.IndividualManagement.Dtos.Profiles
{
    public class IndividualDtoProfile : Profile
    {
        public IndividualDtoProfile()
        {
            CreateMap<Individual, IndividualDto>();

            CreateMap<IndividualDto, Individual>()
                .ConstructUsing(
                    dto =>
                    {
                        var mapper = ProvisioningServiceSingleton.Instance.GetService<IMapper>();
                        var individualFactory = ProvisioningServiceSingleton.Instance.GetService<IIndividualFactory>();

                        var gender = mapper.Map<IndividualGender>(dto.Gender);
                        return individualFactory.CreateIndividual(dto.FirstName, dto.LastName, gender, dto.BirthDate);
                    });
        }
    }
}