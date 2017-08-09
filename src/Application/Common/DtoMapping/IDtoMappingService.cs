namespace Mmu.Ddws.Application.Common.DtoMapping
{
    public interface IDtoMappingService
    {
        TDomainObject MapToDomain<TDto, TDomainObject>(TDto dto);

        TDto MapToDto<TDomainObject, TDto>(TDomainObject domainObject);
    }
}