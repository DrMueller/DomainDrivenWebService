using Mmu.Ddws.Domain.Areas.Common.ModelAbstractions;
using Mmu.Ddws.Domain.Infrastructure.Invariance;

namespace Mmu.Ddws.Domain.Areas.IndividualManagement.Models
{
    public class Address : Entity
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

        public AddressType AddressType { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string Zip { get; private set; }
    }
}