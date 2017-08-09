namespace Mmu.Ddws.Application.Common.DtoMapping
{
    public interface IDtoMapper<TDto, TDomainObject>
    {
        TDomainObject MapToDomainObject(TDto dto);

        TDto MapToDto(TDomainObject domainObject);
    }
}