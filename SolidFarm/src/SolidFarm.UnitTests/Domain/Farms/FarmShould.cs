using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using SolidFarm.Application.Invoices;
using SolidFarm.Domain.Animals;
using SolidFarm.Domain.Farms;
using SolidFarm.Domain.Invoices;
using SolidFarm.Domain.SharedKernel;
using Xunit;

namespace SolidFarm.UnitTests.Domain.Farms
{
    public class FarmShould
    {
        private readonly Farm _farm;

        public FarmShould()
        {
           _farm = new Farm();

           var cow1 = new Cow(DateTime.Now.AddYears(-3));
           var chicken1 = new Chicken(DateTime.Now);
           var chicken2 = new Chicken(DateTime.Now);
           var chicken3 = new Chicken(DateTime.Now);
           var chicken4 = new Chicken(DateTime.Now);

           _farm.DoAnimalWork(cow1, AnimalAction.Bought);
           _farm.DoAnimalWork(cow1, AnimalAction.Sold);

           _farm.DoAnimalWork(chicken1, AnimalAction.Bought);
           _farm.DoAnimalWork(chicken2, AnimalAction.Born);
           _farm.DoAnimalWork(chicken3, AnimalAction.Born);
           _farm.DoAnimalWork(chicken4, AnimalAction.Born);

           _farm.DoAnimalWork(chicken1, AnimalAction.Sold);
           _farm.DoAnimalWork(chicken2, AnimalAction.Sold);
           _farm.DoAnimalWork(chicken3, AnimalAction.Sold);
           _farm.DoAnimalWork(chicken4, AnimalAction.Slaughtered);
        }

        [Fact]
        public void HaveAnimalRecords() => _farm.AnimalRecords.Should().NotBeNullOrEmpty().And.HaveCount(5);

         // Method 1: logic fully in domain
        [Fact]
        public void GenerateInvoicesWithLogicInDomain() =>
            _farm.GetInvoices(DateTime.Now).Should().NotBeNullOrEmpty().And.HaveCount(4);

        // Method 2: inject query, selection + creation of return in domain
        [Fact]
        public void GenerateInvoicesWithInjectedQueryAndLogicInDomain() =>
            _farm.GetInvoices(x => x.Records.Any(y =>
                    y.DateTime.Date.Equals(DateTime.Now.Date) && y.AnimalAction.Equals(AnimalAction.Sold)))
                .Should().NotBeNullOrEmpty().And.HaveCount(4);

        // Method 3: inject query + processing + return
        [Fact]
        public void GenerateInvoicesWithFullInjectionOfQueryAndCreation() =>
            _farm.GetInvoices(
                x => x.Records.Any(
                    y => y.DateTime.Date == DateTime.Now.Date && y.AnimalAction.Equals(AnimalAction.Sold)),
                (records) =>
                {
                    var invoices = new List<Invoice>();
                    foreach (var record in records)
                        invoices.Add(new Invoice(record.Animal.Id, record.Animal, record.Records.FirstOrDefault(x => x.AnimalAction.Equals(AnimalAction.Sold)).DateTime));
                    return invoices;

                }).Should().NotBeNullOrEmpty().And.HaveCount(4);

        // Method 4: inject a class with base class with logic
        [Fact]
        public void GenerateInvoicesForSingleInjectedFilter() =>
            _farm.GetInvoices(new InvoiceFilterForChicken(DateTime.Now))
                .Should().NotBeNullOrEmpty().And.HaveCount(3);

        // Method 5: inject a list of filters
        [Fact]
        public void GenerateInvoicesWithMultipleInjectedFilters() =>
            _farm.GetInvoices(new List<IFilterAndCreate<AnimalRecord, IEnumerable<AnimalRecord>, IEnumerable<Invoice>>>
            {
                new InvoiceFilterForChicken(DateTime.Now),
                new InvoiceFilterForCows(DateTime.Now)
            }).Should().NotBeNullOrEmpty().And.HaveCount(4);

        [Fact]
        public void GenerateInvoicesWithDateRangeFilter()
        {
            var farm = new Farm();

            var cow1 = new Cow(DateTime.Now.AddYears(-10));
            var cow2 = new Cow(DateTime.Now.AddYears(-10));
            var cow3 = new Cow(DateTime.Now.AddYears(-10));
            var cow4 = new Cow(DateTime.Now.AddYears(-10));
            var cow5 = new Cow(DateTime.Now.AddYears(-10));

            farm.DoAnimalWork(cow1, AnimalAction.Bought, DateTime.Now.AddYears(-1));
            farm.DoAnimalWork(cow2, AnimalAction.Bought, DateTime.Now.AddYears(-1));
            farm.DoAnimalWork(cow3, AnimalAction.Bought, DateTime.Now.AddYears(-1));
            farm.DoAnimalWork(cow4, AnimalAction.Bought, DateTime.Now.AddYears(-1));
            farm.DoAnimalWork(cow5, AnimalAction.Bought, DateTime.Now.AddYears(-1));

            farm.DoAnimalWork(cow1, AnimalAction.Sold, DateTime.Now.AddDays(-20));
            farm.DoAnimalWork(cow2, AnimalAction.Sold, DateTime.Now.AddDays(-18));
            farm.DoAnimalWork(cow3, AnimalAction.Sold, DateTime.Now.AddDays(-16));
            farm.DoAnimalWork(cow4, AnimalAction.Sold, DateTime.Now.AddDays(-12));
            farm.DoAnimalWork(cow5, AnimalAction.Sold, DateTime.Now.AddDays(-5));

            var invoices = farm.GetInvoices(new InvoiceFilterForCows(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-10)));

            invoices.Should().NotBeNullOrEmpty().And.HaveCount(4);
        }
    }
}
