using System.Collections.Generic;
using TestedWebApi.Domain.Beers;

namespace TestedWebApi.Application.Beers
{
    public interface IBeerService
    {
        List<Beer> GetAllBeers();

        Beer GetBeerById(int id);

        void UpdateBeer(Beer updatedBeer);
    }
}