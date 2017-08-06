using Mmu.Ddws.Domain.IndividualManagement.Models.AggregateRoots;
using Mmu.Ddws.Domain.IndividualManagement.Models.ValueObjects;

namespace Mmu.Ddws.Domain.Services.IndividualManagement.Factories.Implementation
{
    public class IndividualFactory : IIndividualFactory
    {
        public Individual CreateIndividual(string firstName, string lastName, IndividualGender gender)
        {
            var result = new Individual(firstName, lastName, gender);
            return result;
        }
    }
}