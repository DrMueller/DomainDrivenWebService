﻿using System;
using System.Linq.Expressions;
using Mmu.Ddws.Domain.Areas.Common.ModelAbstractions;
using Mmu.Ddws.Domain.Infrastructure.Specifications.Handlers;

namespace Mmu.Ddws.Domain.Infrastructure.Specifications.Implementation
{
    public class AndSpecification<T> : SpecificationBase<T>
        where T : AggregateRoot
    {
        private readonly SpecificationBase<T> _left;
        private readonly SpecificationBase<T> _right;

        public AndSpecification(SpecificationBase<T> left, SpecificationBase<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}