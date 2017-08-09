using Mmu.Ddws.Domain.IndividualManagement.Models.ValueObjects;
using Mmu.Ddws.Domain.Infrastructure.Invariance;

namespace Mmu.Ddws.Domain.IndividualManagement.Models.Entities
{
    public class Address
    {
        public Address(AddressType addressType, string street, string zip, string city)
        {
            Guard.StringNotNullorEmpty(() => street);
            Guard.StringNotNullorEmpty(() => zip);
            Guard.StringNotNullorEmpty(() => city);

            AddressType = addressType;
            Street = street;
            Zip = zip;
            City = city;
        }

        public AddressType AddressType { get; }

        public string City { get; }

        public string Street { get; }

        public string Zip { get; }
    }
}