using System;
using System.Collections.Generic;
using Mmu.Ddws.Domain.IndividualManagement.Models.Entities;
using Mmu.Ddws.Domain.IndividualManagement.Models.ValueObjects;
using Mmu.Ddws.Domain.Infrastructure.Invariance;
using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;

namespace Mmu.Ddws.Domain.IndividualManagement.Models.AggregateRoots
{
    public class Individual : AggregateRoot
    {
        private readonly List<Address> _addresses;

        public Individual(string firstName, string lastName, IndividualGender gender, DateTime birthDate)
        {
            Guard.StringNotNullorEmpty(() => firstName);
            Guard.StringNotNullorEmpty(() => lastName);
            Guard.ObjectNotNull(() => birthDate);

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            _addresses = new List<Address>();
        }

        public IReadOnlyCollection<Address> Addresses => _addresses;

        public DateTime BirthDate { get; }

        public string FirstName { get; }

        public IndividualGender Gender { get; }

        public string LastName { get; }

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }
    }
}