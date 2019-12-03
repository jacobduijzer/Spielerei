using System;

namespace SolidFarm.Domain.Animals
{
    public class AnimalBase : IAnimal
    {
        public Guid Id { get; }
        public DateTime DateOfBirth { get; }
        public DateTime DateOfDeath { get; }

        public AnimalBase(Guid id, DateTime dateOfBirth)
        {
            Id = id;
            DateOfBirth = dateOfBirth;
        }

        public AnimalBase(Guid id, DateTime dateOfBirth, DateTime dateOfDeath) : this(id, dateOfBirth) =>
            DateOfDeath = dateOfDeath;
    }
}