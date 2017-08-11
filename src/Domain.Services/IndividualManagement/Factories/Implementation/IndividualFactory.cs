using System;
using Mmu.Ddws.Domain.IndividualManagement.Models;

namespace Mmu.Ddws.Domain.Services.IndividualManagement.Factories.Implementation
{
    public class IndividualFactory : IIndividualFactory
    {
        public Individual CreateIndividual(string firstName, string lastName, IndividualGender gender, DateTime birthDate)
        {
            var result = new Individual(firstName, lastName, gender, birthDate);
            return result;
        }
    }
}