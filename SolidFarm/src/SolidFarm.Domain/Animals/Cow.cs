using System;

namespace SolidFarm.Domain.Animals
{
    public class Cow : AnimalBase
    {
        public Cow(DateTime dateOfBirth)
            : base(Guid.NewGuid(), dateOfBirth)
        {
        }

        public Cow(Guid id, DateTime dateOfBirth, DateTime dateOfDeath)
            : base(id, dateOfBirth, dateOfDeath)
        {
        }
    }
}