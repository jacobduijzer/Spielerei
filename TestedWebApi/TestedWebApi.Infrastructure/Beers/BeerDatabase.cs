using System.Collections.Generic;
using TestedWebApi.Domain.Beers;
using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Infrastructure.Beers
{
    public class BeerDatabase : IDatabase<Beer>
    {
        public List<Beer> Items
        {
            get => _items;
            set => _items = value;
        }

        private List<Beer> _items = new List<Beer>
        {
            new Beer { Id = 1, Name = "Real Beer 1"},
            new Beer { Id = 2, Name = "Real Beer 2"}
        };
    }
}