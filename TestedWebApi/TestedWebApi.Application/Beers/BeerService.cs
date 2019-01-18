using System.Collections.Generic;
using TestedWebApi.Domain.Beers;

namespace TestedWebApi.Application.Beers
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository) =>
            _beerRepository = beerRepository;

        public List<Beer> GetAllBeers() =>
            _beerRepository.GetAllBeers();

        public Beer GetBeerById(int id) =>
            _beerRepository.GetBeerById(id);

        public void UpdateBeer(Beer updatedBeer) =>
            _beerRepository.UpdateBeer(updatedBeer);
    }
}