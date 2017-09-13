using System;
using System.Linq.Expressions;
using Mmu.Ddws.Domain.Areas.IndividualManagement.Models;
using Mmu.Ddws.Domain.Infrastructure.Specifications.Implementation;

namespace Mmu.Ddws.Domain.Areas.IndividualManagement.Specifications
{
    public class AdultIndividualSpecification : SpecificationBase<Individual>
    {
        public override Expression<Func<Individual, bool>> ToExpression()
        {
            return i => i.BirthDate <= DateTime.Now.AddYears(-18);
        }
    }
}