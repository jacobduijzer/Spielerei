using LinqBuilder;
using System;
using System.Linq.Expressions;
using TestedWebApi.Domain.Bars;

namespace TestedWebApi.Application.Bars.Specifications
{
    public class BarById : Specification<Bar>
    {
        private int _id;

        public BarById(int id) =>
            _id = id;

        public override Expression<Func<Bar, bool>> AsExpression() =>
            bar => bar.Id == _id;
    }
}