using System.Collections.Generic;

namespace Mmu.Ddws.Common.ServiceProvisioning
{
    public interface IProvisioningService
    {
        IReadOnlyCollection<T> GetAllServices<T>();

        T GetService<T>();
    }
}