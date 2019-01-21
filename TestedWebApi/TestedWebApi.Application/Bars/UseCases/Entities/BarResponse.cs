using TestedWebApi.Domain.Bars;

namespace TestedWebApi.Application.Bars.UseCases
{
    public class BarResponse
    {
        public readonly Bar Bar;

        public BarResponse(Bar bar) =>
            Bar = bar;
    }
}