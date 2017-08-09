using System.Collections.Generic;
using Mmu.Ddws.Common.ServiceProvisioning;
using Mmu.Ddws.Domain.Services.Data.Common.Mapping.Mappers;

namespace Mmu.Ddws.Domain.Services.Data.Common.Mapping.Implementation
{
    public class MappingInitializationService : IMappingInitializationService
    {
        private readonly object _lock = new object();
        private readonly IReadOnlyCollection<IMapper> _mappers;
        private bool _isInitialized;

        public MappingInitializationService(IProvisioningService provisioningService)
        {
            _mappers = provisioningService.GetAllServices<IMapper>();
        }

        public void AssureMappinsgAreInitialized()
        {
            if (_isInitialized)
            {
                return;
            }

            lock (_lock)
            {
                if (_isInitialized)
                {
                    return;
                }

                foreach (var mapper in _mappers)
                {
                    mapper.InitializeMapping();
                }

                _isInitialized = true;
            }
        }
    }
}