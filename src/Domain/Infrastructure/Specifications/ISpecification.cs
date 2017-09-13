using System;
using System.Linq.Expressions;
using Mmu.Ddws.Domain.Areas.Common.ModelAbstractions;

namespace Mmu.Ddws.Domain.Infrastructure.Specifications
{
    public interface ISpecification<T>
        where T : AggregateRoot
    {
        bool IsSatisfiedBy(T aggregateRoot);

        Expression<Func<T, bool>> ToExpression();
    }
}