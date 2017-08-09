using System;
using System.Linq.Expressions;
using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;

namespace Mmu.Ddws.Domain.Infrastructure.Specifications.Implementation
{
    public class NotSpecification<T> : SpecificationBase<T>
        where T : AggregateRoot
    {
        private readonly SpecificationBase<T> _spec;

        public NotSpecification(SpecificationBase<T> spec)
        {
            _spec = spec;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var specExpression = _spec.ToExpression();
            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.Not(specExpression.Body);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}