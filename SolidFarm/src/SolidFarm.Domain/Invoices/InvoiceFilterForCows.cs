using System;
using System.Collections.Generic;
using SolidFarm.Domain.Animals;

namespace SolidFarm.Domain.Invoices
{
    public class InvoiceFilterForCows : InvoiceFilterBase
    {
        public InvoiceFilterForCows(DateTime filterDate) : base(nameof(Cow), filterDate) { }
    }
}