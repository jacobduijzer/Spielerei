using System;
using System.Collections.Generic;
using SolidFarm.Domain.Farms;

namespace SolidFarm.Domain.Animals
{
    public class AnimalRecord
    {
        public readonly IAnimal Animal;

        public readonly List<Record> Records;

        public AnimalRecord(IAnimal animal, DateTime dateTime, AnimalAction animalAction)
        {
            Records = new List<Record>();

            Animal = animal;
            Records.Add(new Record(dateTime, animalAction));
        }

        public void AddAnimalAction(DateTime dateTime, AnimalAction animalAction) => Records.Add(new Record(dateTime, animalAction));
    }
}