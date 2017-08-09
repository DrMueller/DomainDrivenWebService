using System;
using Mmu.Ddws.Domain.IndividualManagement.Models.AggregateRoots;
using Mmu.Ddws.Domain.IndividualManagement.Models.ValueObjects;

namespace Mmu.Ddws.Domain.Services.IndividualManagement.Factories
{
    public interface IIndividualFactory
    {
        Individual CreateIndividual(string firstName, string lastName, IndividualGender gender, DateTime birthDate);
    }
}