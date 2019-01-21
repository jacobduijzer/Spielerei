using System.Collections.Generic;
using TestedWebApi.Domain.Bars;

namespace TestedWebApi.Application.Bars.UseCases
{
    public class BarsResponse
    {
        public readonly List<Bar> Bars;

        public BarsResponse(List<Bar> bars) =>
            Bars = bars;
    }
}