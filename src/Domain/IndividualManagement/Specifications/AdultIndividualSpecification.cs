using System;
using System.Linq.Expressions;
using Mmu.Ddws.Domain.IndividualManagement.Models.AggregateRoots;
using Mmu.Ddws.Domain.Infrastructure.Specifications.Implementation;

namespace Mmu.Ddws.Domain.IndividualManagement.Specifications
{
    public class AdultIndividualSpecification : SpecificationBase<Individual>
    {
        public override Expression<Func<Individual, bool>> ToExpression()
        {
            return i => i.BirthDate.Year >= 18;
        }
    }
}