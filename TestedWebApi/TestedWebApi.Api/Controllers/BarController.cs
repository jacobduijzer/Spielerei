using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestedWebApi.Application.Bars.Specifications;
using TestedWebApi.Application.Bars.UseCases;
using TestedWebApi.Domain.Bars;

namespace TestedWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BarController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bar>>> Get()
        {
            var response = await _mediator.Send(new BarsRequest());
            return response.Bars;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Bar>> GetBarById(int id)
        {
            var response = await _mediator.Send(new BarRequest(new BarById(id)));
            return response.Bar;
        }

        [HttpPost]
        public async Task<ActionResult> UpdateBar([FromBody]Bar updatedBar)
        {
            await _mediator.Send(new UpdateBarRequest(updatedBar));
            return Ok();
        }
    }
}