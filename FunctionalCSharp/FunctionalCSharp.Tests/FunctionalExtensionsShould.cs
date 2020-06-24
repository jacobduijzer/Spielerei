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
                .Filter<int>(x => x % 2 == 0);

            list.Should().BeEquivalentTo(new List<int> { 2, 4, 6, 8, 10 });
        }
    }
}
