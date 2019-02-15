using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FunctionalCSharp.Tests
{
    public class StringFormatterShould
    {
        [Theory]
        [InlineData("red", "good", "desc", "normal", "titleredgooddesc")]
        [InlineData("red", "good", "desc", "biologisch", "titleredgooddescbio")]
        public void formatstring(string kleur, string klasse, string sortering, string teeltwijze, string expectedString) =>
            StringFormatter.GetFormattedName("title", kleur, klasse, sortering, teeltwijze).Should().Be(expectedString);
    }
}
