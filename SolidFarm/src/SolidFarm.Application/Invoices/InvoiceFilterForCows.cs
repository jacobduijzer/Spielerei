using System;
using SolidFarm.Domain.Animals;

namespace SolidFarm.Application.Invoices
{
    public class InvoiceFilterForCows : InvoiceFilterBase
    {
        public InvoiceFilterForCows(DateTime filterDate) : base(nameof(Cow), filterDate) { }
    }
}