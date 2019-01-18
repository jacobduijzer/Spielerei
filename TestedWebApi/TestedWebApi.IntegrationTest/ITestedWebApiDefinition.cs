using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestedWebApi.Domain.Beers;

namespace TestedWebApi.IntegrationTest
{
    public interface ITestedWebApiDefinition
    {
        [Get("/api/beer")]
        Task<List<Beer>> GetAllBeers();

        [Get("/api/beer/{id}")]
        Task<Beer> GetBeerById(int id);

        [Post("/api/beer")]
        Task UpdateBeer([Body]Beer beer);
    }
}