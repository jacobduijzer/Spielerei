using System;
using SolidFarm.Domain.Animals;

namespace SolidFarm.Domain.Invoices
{
    public class Invoice
    {
        public readonly Guid AnimalId;

        public readonly string AnimalType;

        public readonly DateTime DateOfBirth;

        public readonly DateTime DateSold;

        public Invoice(Guid id, IAnimal animal, DateTime dateSold)
        {
            AnimalId = id;
            AnimalType = animal.GetType().Name;
            DateOfBirth = animal.DateOfBirth;
            DateSold = dateSold;
        }
    }
}