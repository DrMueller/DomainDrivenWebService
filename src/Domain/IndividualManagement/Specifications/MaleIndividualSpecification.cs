﻿using System;
using System.Linq.Expressions;
using Mmu.Ddws.Domain.IndividualManagement.Models;
using Mmu.Ddws.Domain.Infrastructure.Specifications.Implementation;

namespace Mmu.Ddws.Domain.IndividualManagement.Specifications
{
    public class MaleIndividualSpecification : SpecificationBase<Individual>
    {
        public override Expression<Func<Individual, bool>> ToExpression()
        {
            return f => f.Gender == IndividualGender.Male;
        }
    }
}