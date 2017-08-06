using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Ddws.Application.IndividualManagement.Dtos;

namespace Mmu.Ddws.Application.IndividualManagement.Services
{
    public interface IIndividualSearchService
    {
        Task<IReadOnlyCollection<IndividualDto>> SearchAllAsync();
    }
}