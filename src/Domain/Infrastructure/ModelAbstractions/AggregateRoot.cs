namespace Mmu.Ddws.Domain.Infrastructure.ModelAbstractions
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