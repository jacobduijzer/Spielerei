using System;

namespace SolidFarm.Domain.Animals
{
    public class Chicken : AnimalBase
    {
        public Chicken(DateTime dateOfBirth)
            : base(Guid.NewGuid(), dateOfBirth)
        {
        }

        public Chicken(Guid id, DateTime dateOfBirth, DateTime dateOfDeath)
            : base(id, dateOfBirth, dateOfDeath)
        {
        }
    }
}