using System.Collections.Generic;
using System.Linq;
using TestedWebApi.Domain.Beers;

namespace TestedWebApi.Infrastructure.Beers
{
    public class BeerRepository : IBeerRepository
    {
        private readonly List<Beer> _beerData = new List<Beer>
        {
            new Beer { Id = 1, Name = "Real Beer 1"},
            new Beer { Id = 2, Name = "Real Beer 2"}
        };

        public List<Beer> GetAllBeers() => _beerData;

        public Beer GetBeerById(int id) =>
            _beerData.FirstOrDefault(beer => beer.Id == id);

        public void UpdateBeer(Beer updatedBeer)
        {
            var existingBeer = _beerData.FirstOrDefault(beer => beer.Id == updatedBeer.Id);
            existingBeer.Name = updatedBeer.Name;
            existingBeer.IsStarred = updatedBeer.IsStarred;
        }
    }
}