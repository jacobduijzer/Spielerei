using LinqBuilder.Core;
using MediatR;
using TestedWebApi.Domain.Bars;

namespace TestedWebApi.Application.Bars.UseCases
{
    public class BarRequest : IRequest<BarResponse>
    {
        public readonly ISpecification<Bar> Specification;

        public BarRequest(ISpecification<Bar> specification) =>
            Specification = specification;
    }
}