using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FunctionalCSharp.Tests
{
    public class ModFunctionsShould
    {
        [Fact]
        public void Test1()
        {
            var list = new ModFunctions().GetEvenNumbers(Enumerable.Range(1, 10));
            list.Should().Contain(new List<int> { 2, 4, 6, 8, 10 });
        }

        [Fact]
        public void Test2()
        {
            var list = new ModFunctions().GetUnevenNumbers(Enumerable.Range(1, 10));
            list.Should().Contain(new List<int> { 1, 3, 5, 7, 9 });
        }
    }
}
