using System.Collections.Generic;

namespace TestedWebApi.Domain.Beers
{
    public interface IBeerRepository
    {
        List<Beer> GetAllBeers();

        Beer GetBeerById(int id);

        void UpdateBeer(Beer updatedBeer);
    }
}