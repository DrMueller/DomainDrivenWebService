﻿using System;
using System.Collections.Generic;
using Mmu.Ddws.Domain.Areas.Common.ModelAbstractions;
using Mmu.Ddws.Domain.Infrastructure.Invariance;

namespace Mmu.Ddws.Domain.Areas.IndividualManagement.Models
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

        public DateTime BirthDate { get; private set; }

        public string FirstName { get; private set; }

        public IndividualGender Gender { get; private set; }

        public string LastName { get; private set; }

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }
    }
}