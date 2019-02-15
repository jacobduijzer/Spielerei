using FluentAssertions;
using Xunit;

namespace FunctionalCSharp.Tests
{
    public class StringFormatterShould
    {
        [Theory]
        [ClassData(typeof(StringFormatterTestData))]
        public void OldStringFormatterFormatstring(string product, string productColor, string productClass, string cultivationType, string expectedString) =>
            OldStringFormatter.GetFormattedName(product, productColor, productClass, cultivationType)
                .Should().Be(expectedString);

        [Theory] 
        [ClassData(typeof(StringFormatterTestData))]
        public void StringFormatter1Formatstring(string product, string productColor, string productClass, string cultivationType, string expectedString) =>
            StringFormatter1.GetFormattedName(product, productColor, productClass, cultivationType)
                .Should().Be(expectedString);

        [Theory]
        [ClassData(typeof(StringFormatterTestData))]
        public void StringFormatter2Formatstring(string product, string productColor, string productClass, string cultivationType, string expectedString) =>
            StringFormatter2.GetFormattedName(product, productColor, productClass, cultivationType)
                .Should().Be(expectedString);
    }
}
