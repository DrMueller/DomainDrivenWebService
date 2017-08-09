using System.Threading.Tasks;
using Mmu.Ddws.Application.Common.DtoMapping;
using Mmu.Ddws.Application.IndividualManagement.Dtos;
using Mmu.Ddws.Domain.IndividualManagement.Models.AggregateRoots;
using Mmu.Ddws.Domain.Services.Common.Repositories;

namespace Mmu.Ddws.Application.IndividualManagement.Services.Implementation
{
    public class IndividualUpdateService : IIndividualUpdateService
    {
        private readonly IDtoMappingService _mappingService;
        private readonly IRepositoryFactory _repositoryFactory;

        public IndividualUpdateService(IRepositoryFactory repositoryFactory, IDtoMappingService mappingService)
        {
            _repositoryFactory = repositoryFactory;
            _mappingService = mappingService;
        }

        public async Task<IndividualDto> SaveIndividualAsync(IndividualDto individualDto)
        {
            var individual = _mappingService.MapToDomain<IndividualDto, Individual>(individualDto);
            var individualRepository = _repositoryFactory.CreateRepository<Individual>();

            var returnedIndividual = await individualRepository.SaveAsync(individual);

            var result = _mappingService.MapToDto<Individual, IndividualDto>(returnedIndividual);
            return result;
        }
    }
}