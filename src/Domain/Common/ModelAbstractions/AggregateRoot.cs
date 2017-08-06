namespace Mmu.Ddws.Domain.Common.ModelAbstractions
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot()
        {
            AggregateTypeName = GetType().FullName;
        }

        public string AggregateTypeName { get; set; }
    }
}