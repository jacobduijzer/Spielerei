using System;
using SolidFarm.Domain.Animals;

namespace SolidFarm.Domain.Invoices
{
    public class InvoiceFilterForChicken : InvoiceFilterBase
    {
        public InvoiceFilterForChicken(DateTime filterDate)
            : base(nameof(Chicken), filterDate)
        {
        }
    }
}