using System;
using Mmu.Ddws.Domain.Areas.IndividualManagement.Models;

namespace Mmu.Ddws.Domain.Services.Areas.IndividualManagement.Factories
{
    public interface IIndividualFactory
    {
        Individual CreateIndividual(string firstName, string lastName, IndividualGender gender, DateTime birthDate);
    }
}