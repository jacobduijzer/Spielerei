using System.Collections.Generic;
using TestedWebApi.Domain.Beers;
using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Application.Beers
{
    public class BeerService : IBeerService
    {
        private readonly IRepository<Beer> _beerRepository;

        public BeerService(IRepository<Beer> beerRepository) =>
            _beerRepository = beerRepository;

        public List<Beer> GetAllBeers() =>
            _beerRepository.GetAll();

        public Beer GetBeerById(int id) =>
            _beerRepository.GetById(id);

        public void UpdateBeer(Beer updatedBeer) =>
            _beerRepository.Update(updatedBeer);
    }
}