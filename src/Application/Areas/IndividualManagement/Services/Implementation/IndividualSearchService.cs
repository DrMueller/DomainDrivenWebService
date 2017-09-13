using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Ddws.Application.Areas.IndividualManagement.Dtos;
using Mmu.Ddws.Domain.Areas.IndividualManagement.Models;
using Mmu.Ddws.Domain.Areas.IndividualManagement.Specifications;
using Mmu.Ddws.Domain.Services.Infrastructure.Repositories;

namespace Mmu.Ddws.Application.Areas.IndividualManagement.Services.Implementation
{
    public class IndividualSearchService : IIndividualSearchService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryFactory _repositoryFactory;

        public IndividualSearchService(IRepositoryFactory repositoryFactory, IMapper mapper)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<IndividualDto>> SearchAllAsync()
        {
            var individualRepository = _repositoryFactory.CreateRepository<Individual>();
            var allIndividuals = await individualRepository.LoadAllAsync();
            var result = _mapper.Map<List<IndividualDto>>(allIndividuals).ToList();

            return result;
        }

        public async Task<IReadOnlyCollection<IndividualDto>> SearchFemaleAdultsOrChildrenAsync()
        {
            var maleSpec = new MaleIndividualSpecification();
            var adultSpec = new AdultIndividualSpecification();
            var childSpec = new ChildIndividualSpecification();

            // Expressions always seem to evaluted and then passed 
            // Therefore, this one does not return male children
            ////var searchSpec = adultSpec.Or(childSpec).And(maleSpec.Not());

            // This one returns all female women and all children
            var searchSpec = adultSpec.And(maleSpec.Not()).Or(childSpec);

            var individualRepository = _repositoryFactory.CreateRepository<Individual>();
            var foundIndividuals = await individualRepository.LoadAsync(searchSpec);

            var result = _mapper.Map<List<IndividualDto>>(foundIndividuals).ToList();
            return result;
        }
    }
}