using AutoMapper;
using Mmu.Ddws.Common.ServiceProvisioning;
using Mmu.Ddws.Domain.Areas.IndividualManagement.Models;
using Mmu.Ddws.Domain.Services.Areas.IndividualManagement.Factories;

namespace Mmu.Ddws.Application.Areas.IndividualManagement.Dtos.Profiles
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