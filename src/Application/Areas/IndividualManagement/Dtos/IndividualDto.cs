using System;

namespace Mmu.Ddws.Application.Areas.IndividualManagement.Dtos
{
    public class IndividualDto
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public IndividualGenderDto Gender { get; set; }

        public string Id { get; set; }

        public string LastName { get; set; }
    }
}