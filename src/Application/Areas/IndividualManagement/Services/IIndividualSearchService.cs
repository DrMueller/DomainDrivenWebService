using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Ddws.Application.Areas.IndividualManagement.Dtos;

namespace Mmu.Ddws.Application.Areas.IndividualManagement.Services
{
    public interface IIndividualSearchService
    {
        Task<IReadOnlyCollection<IndividualDto>> SearchAllAsync();

        Task<IReadOnlyCollection<IndividualDto>> SearchFemaleAdultsOrChildrenAsync();
    }
}