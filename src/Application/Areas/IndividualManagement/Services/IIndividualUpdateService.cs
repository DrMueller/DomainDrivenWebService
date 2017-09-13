using System.Threading.Tasks;
using Mmu.Ddws.Application.Areas.IndividualManagement.Dtos;

namespace Mmu.Ddws.Application.Areas.IndividualManagement.Services
{
    public interface IIndividualUpdateService
    {
        Task<IndividualDto> SaveIndividualAsync(IndividualDto individualDto);
    }
}