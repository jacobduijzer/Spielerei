using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestedWebApi.Domain.Bars;
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

        [Get("/api/bar")]
        Task<List<Bar>> GetAllBars();

        [Get("/api/bar/{id}")]
        Task<Bar> GetBarById(int id);

        [Post("/api/bar")]
        Task UpdateBar([Body]Bar bar);
    }
}