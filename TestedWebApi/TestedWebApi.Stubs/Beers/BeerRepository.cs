using System.Collections.Generic;
using System.Linq;
using TestedWebApi.Domain.Beers;

namespace TestedWebApi.Stubs.Beers
{
    public class BeerRepository : IBeerRepository
    {
        private readonly List<Beer> _beerData = new List<Beer>
        {
            new Beer { Id = 1, Name = "Stubbed Beer 1"},
            new Beer { Id = 2, Name = "Stubbed Beer 2"}
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