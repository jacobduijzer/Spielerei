using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FunctionalCSharp.Tests
{
    public class StringFormatterShould
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void OldStringFormatterFormatstring(string product, string productColor, string productClass,
            string cultivationType, string expectedString) =>
            OldStringFormatter.GetFormattedName(product, productColor, productClass, cultivationType)
                .Should().Be(expectedString);

        [Theory]
        [MemberData(nameof(TestData))]
        public void StringFormatter1Formatstring(string product, string productColor, string productClass,
            string cultivationType, string expectedString) =>
            StringFormatter1.GetFormattedName(product, productColor, productClass, cultivationType)
                .Should().Be(expectedString);

        [Theory]
        [MemberData(nameof(TestData))]
        public void StringFormatter2Formatstring(string product, string productColor, string productClass,
            string cultivationType, string expectedString) =>
            StringFormatter2.GetFormattedName(product, productColor, productClass, cultivationType)
                .Should().Be(expectedString);

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] {"strawberry", "red", "first class", "normal", "strawberry, red, first class"},
                new object[] {"strawberry", "red", "first class", "biologic", "strawberry, red, first class (BIO)"},
                new object[] {"strawberry", "", "first class", "biologic", "strawberry, first class (BIO)"},
                new object[] {"strawberry", "", "", "biologic", "strawberry (BIO)"},
                new object[] {"strawberry", "", "", "normal", "strawberry"},
                new object[] {"strawberry", "red", "", "normal", "strawberry, red"},
                new object[] {"strawberry", "red", "", "biologic", "strawberry, red (BIO)"},
            };
    }
}