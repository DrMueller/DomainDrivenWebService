using System.Collections.Generic;
using Mmu.Ddws.Domain.Common.Invariance;
using Mmu.Ddws.Domain.Common.ModelAbstractions;
using Mmu.Ddws.Domain.IndividualManagement.Models.Entities;
using Mmu.Ddws.Domain.IndividualManagement.Models.ValueObjects;

namespace Mmu.Ddws.Domain.IndividualManagement.Models.AggregateRoots
{
    public class Individual : AggregateRoot
    {
        private readonly List<Address> _addresses;

        public Individual(string firstName, string lastName, IndividualGender gender)
        {
            Guard.StringNotNullorEmpty(() => firstName);
            Guard.StringNotNullorEmpty(() => lastName);

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            _addresses = new List<Address>();
        }

        public IReadOnlyCollection<Address> Addresses => _addresses;

        public string FirstName { get; }

        public IndividualGender Gender { get; }

        public string LastName { get; }

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }
    }
}