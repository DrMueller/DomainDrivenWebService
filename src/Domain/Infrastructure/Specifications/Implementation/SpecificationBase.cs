using System;
using System.Linq.Expressions;
using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;

namespace Mmu.Ddws.Domain.Infrastructure.Specifications.Implementation
{
    public abstract class SpecificationBase<T> : ISpecification<T>
        where T : AggregateRoot
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public SpecificationBase<T> And(SpecificationBase<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public SpecificationBase<T> Not(SpecificationBase<T> specification)
        {
            return new NotSpecification<T>(specification);
        }

        public SpecificationBase<T> Or(SpecificationBase<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public bool IsSatisfiedBy(T aggregateRoot)
        {
            var predicate = ToExpression().Compile();
            var result = predicate(aggregateRoot);

            return result;
        }
    }
}