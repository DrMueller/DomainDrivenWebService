namespace Mmu.Ddws.Application.Common.Mapping
{
    public interface IMappingService
    {
        TDomainObject MapToDomain<TDto, TDomainObject>(TDto dto);

        TDto MapToDto<TDomainObject, TDto>(TDomainObject domainObject);
    }
}