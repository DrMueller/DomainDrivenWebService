using System.Threading.Tasks;
using Mmu.Ddws.Application.IndividualManagement.Dtos;

namespace Mmu.Ddws.Application.IndividualManagement.Services
{
    public interface IIndividualUpdateService
    {
        Task<IndividualDto> SaveIndividualAsync(IndividualDto individualDto);
    }
}