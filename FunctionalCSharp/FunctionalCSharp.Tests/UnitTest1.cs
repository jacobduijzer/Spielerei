using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FunctionalCSharp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var list = new Functional().GetEvenNumbers(Enumerable.Range(1, 10));
            list.Should().Contain(new List<int> { 2, 4, 6, 8, 10});
        }

        [Fact]
        public void Test2()
        {
            var list = new Functional().GetUnevenNumbers(Enumerable.Range(1, 10));
            list.Should().Contain(new List<int> { 1, 3, 5, 7, 9 });
        }

        [Fact]
        public void Test3()
        {
            var list = Enumerable
                .Range(1, 10)
                .Where<int>(x => x % 2 == 0);

            list.Should().Contain(new List<int> { 2, 4, 6, 8, 10 });
        }
    }
}
