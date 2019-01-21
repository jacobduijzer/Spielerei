using System.Collections.Generic;
using TestedWebApi.Domain.Beers;
using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Stubs.Beers
{
    public class StubBeerDatabase : IDatabase<Beer>
    {
        public List<Beer> Items
        {
            get => _items;
            set => _items = value;
        }

        private List<Beer> _items = new List<Beer>
        {
            new Beer { Id = 1, Name = "Stubbed Beer 1"},
            new Beer { Id = 2, Name = "Stubbed Beer 2"}
        };
    }
}