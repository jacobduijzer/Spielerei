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

        public InvoiceFilterForChicken(DateTime startDate, DateTime endDate)
            : base(nameof(Chicken), startDate, endDate)
        {
        }
    }
}