using System;
using System.Collections.Generic;
using SolidFarm.Domain.Animals;

namespace SolidFarm.Domain.SharedKernel
{
    public interface IFilterAndCreate<TFilterObject, TCreateIn, TCreateOut>
    {
        Predicate<TFilterObject> Filter { get; }
        Func<TCreateIn, TCreateOut> Create { get; }
    }
}