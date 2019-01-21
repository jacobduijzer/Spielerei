using System.Collections.Generic;
using TestedWebApi.Domain.Bars;
using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Infrastructure.Bars
{
    public class BarDatabase : IDatabase<Bar>
    {
        private List<Bar> _items = new List<Bar>
        {
            new Bar { Id = 1, Name = "Oud Zuid", City = "Vught", IsFavorite = true },
            new Bar { Id = 2, Name = "'t Paultje", City = "'s-Hertogenbosch"}
        };

        public List<Bar> Items
        {
            get => _items;
            set => _items = value;
        }
    }
}