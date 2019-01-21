using System.Collections.Generic;
using TestedWebApi.Domain.Bars;
using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Stubs.Bars
{
    public class StubBarDatabase : IDatabase<Bar>
    {
        private List<Bar> _items = new List<Bar>
        {
            new Bar { Id = 1, Name = "Stubbed Bar 1", City = "StubVillage", IsFavorite = true },
            new Bar { Id = 2, Name = "Stubbed Bar 2", City = "StubCity"}
        };

        public List<Bar> Items
        {
            get => _items;
            set => _items = value;
        }
    }
}