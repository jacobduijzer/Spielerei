using System;
using SolidFarm.Domain.Animals;
using SolidFarm.Domain.Farms;

namespace SolidFarm.Domain
{
    public class Record
    {
        public readonly DateTime DateTime;
        public readonly AnimalAction AnimalAction;

        public Record(DateTime dateTime, AnimalAction animalAction)
        {
            DateTime = dateTime;
            AnimalAction = animalAction;
        }
    }
}