using FluentAssertions;
using System;
using Xunit;

namespace CustomMapper.Tests
{
    public class CustomMapperShould
    {
        private readonly CustomMapper.Core.CustomMapper _customMapper;

        public CustomMapperShould() =>
            _customMapper = new Core.CustomMapper();

        [Fact]
        public void Construct() =>
            _customMapper.Should()
                            .BeOfType<CustomMapper.Core.CustomMapper>();

        [Theory]
        [InlineData("0", false)]
        [InlineData("1", true)]
        [InlineData("asd", false)]
        public void MapStringToBool(string input, bool expectedValue)
        {
            _customMapper.Map(x => x == "1" ? true : false, input)
                .Should()
                .Be(expectedValue);
        }

        [Theory]
        [InlineData("0", false)]
        [InlineData("1", true)]
        [InlineData("asd", false)]
        public void MapStringToBoolWithStoredMapper(string input, bool expectedValue)
        {
            _customMapper.WithMapStringToBool(x => x == "1" ? true : false);
            _customMapper.MapStringToBool(input).Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("Cat", "caboom")]
        [InlineData("Cow", "booh")]
        [InlineData("Dog", "caboom")]
        public void MapStringToString(string input, string expectedResult) =>
            _customMapper.MapStringToObject<string>(x => x.ToLower() == "cow" ? "booh" : "caboom", input)
                .Should()
                .Be(expectedResult);

        [Theory]
        [InlineData("Cat", "caboom")]
        [InlineData("Cow", "booh")]
        [InlineData("Dog", "caboom")]
        public void MapStringToStringWithStoredMapper(string input, string expectedResult)
        {
            _customMapper.WithGenericMapper(x => x.ToLower() == "cow" ? "booh" : "caboom");
            _customMapper.GenericMapper<string>(input).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("f", TestEnum.Female)]
        [InlineData("m", TestEnum.Male)]
        [InlineData("Peter", TestEnum.Alien)]
        [InlineData("xx", TestEnum.Unknown)]
        public void MapStringToEnumWithStoredMapper(string input, TestEnum expectedResult)
        {
            _customMapper.WithGenericMapper(x =>
            {
                switch (x)
                {
                    case "f": return TestEnum.Female;
                    case "m": return TestEnum.Male;
                    case "Peter": return TestEnum.Alien;
                    default: return TestEnum.Unknown;
                }
            });
            _customMapper.GenericMapper<TestEnum>(input).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("f", TestEnum.Female)]
        [InlineData("m", TestEnum.Male)]
        [InlineData("Peter", TestEnum.Alien)]
        [InlineData("xx", TestEnum.Unknown)]
        public void Test(string input, TestEnum expectedResult)
        {
            _customMapper.WithGenericMapper(x =>
            {
                switch (x)
                {
                    case "f": return TestEnum.Female;
                    case "m": return TestEnum.Male;
                    case "Peter": return TestEnum.Alien;
                    default: return TestEnum.Unknown;
                }
            });

            var type = typeof(TestEnum);
            var value = Activator.CreateInstance(type);
            value = Convert.ChangeType(_customMapper.DynamicMapper(input), value.GetType());
            value.Should().Be(expectedResult);
        }
    }
}