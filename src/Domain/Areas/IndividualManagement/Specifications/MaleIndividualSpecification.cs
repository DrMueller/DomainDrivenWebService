using System;
using System.Linq.Expressions;
using Mmu.Ddws.Domain.Areas.IndividualManagement.Models;
using Mmu.Ddws.Domain.Infrastructure.Specifications.Implementation;

namespace Mmu.Ddws.Domain.Areas.IndividualManagement.Specifications
{
    public class MaleIndividualSpecification : SpecificationBase<Individual>
    {
        public override Expression<Func<Individual, bool>> ToExpression()
        {
            return f => f.Gender == IndividualGender.Male;
        }
    }
}