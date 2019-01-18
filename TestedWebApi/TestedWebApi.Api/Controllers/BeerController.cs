using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestedWebApi.Application.Beers;
using TestedWebApi.Domain.Beers;

namespace TestedWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService) =>
            _beerService = beerService;

        [HttpGet]
        public ActionResult<IEnumerable<Beer>> Get()
        {
            return _beerService.GetAllBeers();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Beer> GetBeerById(int id)
        {
            return _beerService.GetBeerById(id);
        }

        [HttpPost]
        public ActionResult UpdateBeer([FromBody]Beer updatedBeer)
        {
            _beerService.UpdateBeer(updatedBeer);
            return Ok();
        }
    }
}