using System;
using Mmu.Ddws.Common.ServiceProvisioning;

namespace Mmu.Ddws.Application.Common.DtoMapping.Implementation
{
    public class DtoMappingService : IDtoMappingService
    {
        private readonly IProvisioningService _provisioningService;

        public DtoMappingService(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public TDomainObject MapToDomain<TDto, TDomainObject>(TDto dto)
        {
            return GetHandler<TDto, TDomainObject>().MapToDomainObject(dto);
        }

        public TDto MapToDto<TDomainObject, TDto>(TDomainObject domainObject)
        {
            return GetHandler<TDto, TDomainObject>().MapToDto(domainObject);
        }

        private IDtoMapper<TDto, TDomainObject> GetHandler<TDto, TDomainObject>()
        {
            var handler = _provisioningService.GetService<IDtoMapper<TDto, TDomainObject>>();
            if (handler == null)
            {
                var dtoTypeName = typeof(TDto).Name;
                var domainObjectTypeName = typeof(TDomainObject).Name;
                throw new ArgumentException($"No Mapping registered for DTO {dtoTypeName} and DomainObject {domainObjectTypeName}.");
            }

            return handler;
        }
    }
}