![](https://github.com/jacobduijzer/Spielerei/workflows/SolidFarm/badge.svg) 

# Introduction

While working at a large project with some complex flows I thought of ways to implement a more S.O.L.I.D. service to filter items and create new objects with the selected items.

Imagine you have a list with actions:

- chicken 1, female, born 1-1-2019, sold 1-3-2019
- chicken 2, female, born 1-1-2019, sold 1-3-2019
- chicken 3, male, born 2-1-2019, slaughtered 31-4-2019

I want to select all sold females between 1-1-2019 and 31-1-2019 to create invoices.

While there might be many ways to Rome I want to emphasize that:

- selections might change
- new selections might be added
- creation of the invoice might be different based on selected animals

## One interface to filter and create them all

I created the following interface:

```csharp
public interface IFilterAndCreate<TFilterObject, TCreateIn, TCreateOut>
{
    Predicate<TFilterObject> Filter { get; }
    Func<TCreateIn, TCreateOut> Create { get; }
}
```

## Sample implementation

An implementation of the interface I used a base class here because I filter on cow's and chickens which are both ```IAnimal```) could look like this:

```csharp
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
```

```csharp
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
```

The actual usage in a service:

```csharp
public IEnumerable<Invoice> GetInvoices(List<IFilterAndCreate<AnimalRecord, IEnumerable<AnimalRecord>, IEnumerable<Invoice>>> filters) =>
    filters.SelectMany(filter => filter.Create(AnimalRecords.FindAll(filter.Filter)));
```
