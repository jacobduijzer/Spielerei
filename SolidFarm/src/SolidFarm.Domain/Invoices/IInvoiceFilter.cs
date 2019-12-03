using System;
using System.Collections.Generic;
using SolidFarm.Domain.Animals;

namespace SolidFarm.Domain.Invoices
{
    public interface IInvoiceFilter
    {
        Predicate<AnimalRecord> Filter { get; }

        Func<IEnumerable<AnimalRecord>, IEnumerable<Invoice>> Create { get; }
    }
}