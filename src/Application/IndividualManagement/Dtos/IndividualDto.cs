using System;

namespace Mmu.Ddws.Application.IndividualManagement.Dtos
{
    public class IndividualDto
    {
        public string FirstName { get; set; }

        public IndividualGenderDto Gender { get; set; }

        public string Id { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}