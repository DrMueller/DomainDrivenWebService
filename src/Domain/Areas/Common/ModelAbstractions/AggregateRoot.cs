namespace Mmu.Ddws.Domain.Areas.Common.ModelAbstractions
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot()
        {
            AggregateTypeName = GetType().FullName;
        }

        public string AggregateTypeName { get; }
    }
}