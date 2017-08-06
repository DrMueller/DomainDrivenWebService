namespace Mmu.Ddws.Application.Common.Mapping
{
    public interface IMapper<TDto, TDomainObject>
    {
        TDomainObject MapToDomainObject(TDto dto);

        TDto MapToDto(TDomainObject domainObject);
    }
}