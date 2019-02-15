using System;

namespace FunctionalCSharp
{
    public static class StringFormatter
    {
        public static string GetFormattedName(string startName, string kleur, string klasse, string sortering, string teeltwijze) =>
            startName
            .AddNamePart(kleur)
            .AddNamePart(klasse)
            .AddNamePart(sortering)
            .AddNamePart("bio", () => !string.IsNullOrEmpty(teeltwijze) && teeltwijze == "biologisch");

        private static string AddNamePart(this string formattedstring, string value) =>
            !string.IsNullOrEmpty(value) ? formattedstring + value : formattedstring;

        private static string AddNamePart(this string formattedstring, string value, Func<bool> testExpression) =>
            testExpression() == true ? formattedstring + value : formattedstring;
    }
}
