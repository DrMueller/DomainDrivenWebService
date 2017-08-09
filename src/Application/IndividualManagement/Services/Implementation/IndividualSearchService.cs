using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Ddws.Application.Common.DtoMapping;
using Mmu.Ddws.Application.IndividualManagement.Dtos;
using Mmu.Ddws.Domain.IndividualManagement.Models.AggregateRoots;
using Mmu.Ddws.Domain.IndividualManagement.Specifications;
using Mmu.Ddws.Domain.Services.Common.Repositories;

namespace Mmu.Ddws.Application.IndividualManagement.Services.Implementation
{
    public class IndividualSearchService : IIndividualSearchService
    {
        private readonly IDtoMappingService _mappingService;
        private readonly IRepositoryFactory _repositoryFactory;

        public IndividualSearchService(IRepositoryFactory repositoryFactory, IDtoMappingService mappingService)
        {
            _repositoryFactory = repositoryFactory;
            _mappingService = mappingService;
        }

        public async Task<IReadOnlyCollection<IndividualDto>> SearchAllAsync()
        {
            var individualRepository = _repositoryFactory.CreateRepository<Individual>();
            var allIndividuals = await individualRepository.LoadAllAsync();
            var result = allIndividuals.Select(f => _mappingService.MapToDto<Individual, IndividualDto>(f)).ToList();

            return result;
        }

        public async Task<IReadOnlyCollection<IndividualDto>> SearchFemaleAdultsAsync()
        {
            var maleSpec = new MaleIndividualSpecification();
            var adultSpec = new AdultIndividualSpecification();

            //var searchSpec = adultSpec.Not(maleSpec);

            var individualRepository = _repositoryFactory.CreateRepository<Individual>();
            var femaleAdultIndividuals = await individualRepository.LoadAsync(adultSpec);
            var result = femaleAdultIndividuals.Select(f => _mappingService.MapToDto<Individual, IndividualDto>(f)).ToList();

            return result;
        }
    }
}