using System.Threading.Tasks;
using AutoMapper;
using Mmu.Ddws.Application.IndividualManagement.Dtos;
using Mmu.Ddws.Domain.IndividualManagement.Models;
using Mmu.Ddws.Domain.Services.Common.Repositories;

namespace Mmu.Ddws.Application.IndividualManagement.Services.Implementation
{
    public class IndividualUpdateService : IIndividualUpdateService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryFactory _repositoryFactory;

        public IndividualUpdateService(IRepositoryFactory repositoryFactory, IMapper mapper)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
        }

        public async Task<IndividualDto> SaveIndividualAsync(IndividualDto individualDto)
        {
            var individual = _mapper.Map<Individual>(individualDto);
            var individualRepository = _repositoryFactory.CreateRepository<Individual>();

            var returnedIndividual = await individualRepository.SaveAsync(individual);

            var result = _mapper.Map<IndividualDto>(returnedIndividual);

            return result;
        }
    }
}