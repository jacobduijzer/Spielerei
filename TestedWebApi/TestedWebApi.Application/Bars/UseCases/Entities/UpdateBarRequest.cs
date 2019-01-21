using MediatR;
using TestedWebApi.Domain.Bars;

namespace TestedWebApi.Application.Bars.UseCases
{
    public class UpdateBarRequest : IRequest
    {
        public readonly Bar Bar;

        public UpdateBarRequest(Bar bar) =>
            Bar = bar;
    }
}