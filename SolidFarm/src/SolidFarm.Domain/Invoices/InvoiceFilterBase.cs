using System;
using System.Collections.Generic;
using System.Linq;
using SolidFarm.Domain.Animals;

namespace SolidFarm.Domain.Invoices
{
    public class InvoiceFilterBase: IInvoiceFilter
    {
        public Predicate<AnimalRecord> Filter { get; }
        public virtual Func<IEnumerable<AnimalRecord>, IEnumerable<Invoice>> Create => (records) =>
        {
            var invoices = new List<Invoice>();
            foreach(var record in records)
                invoices.Add(new Invoice(record.Animal.Id, record.Animal, record.Records.FirstOrDefault(x => x.AnimalAction.Equals(AnimalAction.Sold)).DateTime));
            return invoices;
        };

        public InvoiceFilterBase(string animalType, DateTime filterDate) =>
            Filter = new Predicate<AnimalRecord>(x => x != null && (x.Animal.GetType().Name.Equals(animalType) &&
                                                                    x.Records.Any(y => y.DateTime.Date.Equals(filterDate.Date) && y.AnimalAction.Equals(AnimalAction.Sold))));
    }
}