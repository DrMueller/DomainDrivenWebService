using System;
using StructureMap;

namespace Mmu.Ddws.Application.Common.Mapping.Implementation
{
    public class MappingService : IMappingService
    {
        private readonly IContainer _container;

        public MappingService(IContainer container)
        {
            _container = container;
        }

        public TDomainObject MapToDomain<TDto, TDomainObject>(TDto dto)
        {
            return GetHandler<TDto, TDomainObject>().MapToDomainObject(dto);
        }

        public TDto MapToDto<TDomainObject, TDto>(TDomainObject domainObject)
        {
            return GetHandler<TDto, TDomainObject>().MapToDto(domainObject);
        }

        private IMapper<TDto, TDomainObject> GetHandler<TDto, TDomainObject>()
        {
            var handler = _container.GetInstance<IMapper<TDto, TDomainObject>>();
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