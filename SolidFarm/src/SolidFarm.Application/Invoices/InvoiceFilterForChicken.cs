using System;
using SolidFarm.Domain.Animals;

namespace SolidFarm.Application.Invoices
{
    public class InvoiceFilterForChicken : InvoiceFilterBase
    {
        public InvoiceFilterForChicken(DateTime filterDate)
            : base(nameof(Chicken), filterDate)
        {
        }
    }
}