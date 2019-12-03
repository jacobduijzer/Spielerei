using System;

namespace SolidFarm.Domain.Animals
{
    public interface IAnimal
    {
        Guid Id { get;  }
        DateTime DateOfBirth { get; }
        DateTime DateOfDeath { get;  }
    }
}