using System;
using System.Collections.Generic;
using System.Linq;
using SolidFarm.Domain.Animals;
using SolidFarm.Domain.Invoices;
using SolidFarm.Domain.SharedKernel;

namespace SolidFarm.Domain.Farms
{
    public class Farm
    {
        public readonly List<AnimalRecord> AnimalRecords;

        public Farm() => AnimalRecords = new List<AnimalRecord>();

        public void DoAnimalWork(IAnimal animal, AnimalAction animalAction) =>
            DoAnimalWork(animal, animalAction, DateTime.Now);

        public void DoAnimalWork(IAnimal animal, AnimalAction animalAction, DateTime actionDate)
        {
            if (AnimalRecords.Any(x => x.Animal.Id.Equals(animal.Id)))
                AnimalRecords.First(x => x.Animal.Id.Equals(animal.Id)).AddAnimalAction(actionDate, animalAction);
            else
                AnimalRecords.Add(new AnimalRecord(animal, actionDate, animalAction));
        }

        public IEnumerable<Invoice> GetInvoices(DateTime date)
        {
            var invoices = new List<Invoice>();
            var animals = AnimalRecords.Where(x =>
                x.Records.Any(y => y.DateTime.Date == date.Date && y.AnimalAction == AnimalAction.Sold));
            foreach (var animal in animals)
                invoices.Add(new Invoice(animal.Animal.Id, animal.Animal, animal.Records.FirstOrDefault(x => x.AnimalAction.Equals(AnimalAction.Sold)).DateTime));

            return invoices;
        }

        // Method 1: logic fully in domain
        public IEnumerable<Invoice> GetInvoices(Predicate<AnimalRecord> predicate)
        {
            var invoices = new List<Invoice>();
            var animals = AnimalRecords.FindAll(predicate);
            foreach (var animal in animals)
                invoices.Add(new Invoice(animal.Animal.Id, animal.Animal, animal.Records.FirstOrDefault(x => x.AnimalAction.Equals(AnimalAction.Sold)).DateTime));

            return invoices;
        }

        // Method 2: inhect query, logic in domain
        public IEnumerable<Invoice> GetInvoices(Predicate<AnimalRecord> predicate, Func<List<AnimalRecord>, List<Invoice>> create) =>
                create(AnimalRecords.FindAll(predicate));

        // Method 4: inject a filter
        public IEnumerable<Invoice> GetInvoices(IFilterAndCreate<AnimalRecord, IEnumerable<AnimalRecord>, IEnumerable<Invoice>> filter) =>
            filter.Create(AnimalRecords.FindAll(filter.Filter));

        // Method 5: multiple filters
        public IEnumerable<Invoice> GetInvoices(List<IFilterAndCreate<AnimalRecord, IEnumerable<AnimalRecord>, IEnumerable<Invoice>>> filters) =>
            filters.SelectMany(filter => filter.Create(AnimalRecords.FindAll(filter.Filter)));
    }
}