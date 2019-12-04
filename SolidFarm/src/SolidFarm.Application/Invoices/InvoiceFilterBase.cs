using System;
using System.Collections.Generic;
using System.Linq;
using SolidFarm.Domain.Animals;
using SolidFarm.Domain.Invoices;
using SolidFarm.Domain.SharedKernel;

namespace SolidFarm.Application.Invoices
{
    public class InvoiceFilterBase : IFilterAndCreate<AnimalRecord, IEnumerable<AnimalRecord>, IEnumerable<Invoice>>
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

        public InvoiceFilterBase(string animalType, DateTime startDate, DateTime endDate) =>
            Filter = new Predicate<AnimalRecord>(x => x != null && x.Animal.GetType().Name.Equals(animalType) &&
                                                      x.Records.Any(y =>
                                                          ( y.DateTime.Date >= startDate.Date &&
                                                            y.DateTime.Date <= endDate.Date) &&
                                                          y.AnimalAction.Equals(AnimalAction.Sold)));
    }
}
