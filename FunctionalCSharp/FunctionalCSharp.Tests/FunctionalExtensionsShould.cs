using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FunctionalCSharp.Tests
{
    public class FunctionalExtensionsShould
    {
        [Fact]
        public void ReturnEvenNumbers()
        {
            var list = Enumerable
                .Range(1, 10)
                .Where<int>(x => x % 2 == 0);

            list.Should().Contain(new List<int> { 2, 4, 6, 8, 10 });
        }
    }
}
