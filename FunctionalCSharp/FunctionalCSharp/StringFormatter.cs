using System;

namespace FunctionalCSharp
{
    public static class StringFormatter2
    {
        public static string GetFormattedName(string productName, string productColor, string productClass, string cultivationType) =>
            productName
            .AddNamePart($", {productColor}", () => !string.IsNullOrEmpty(productColor))
            .AddNamePart($", {productClass}", () => !string.IsNullOrEmpty(productClass))
            .AddNamePart(" (BIO)", () => !string.IsNullOrEmpty(cultivationType) && cultivationType.Equals("biologic"));

        private static string AddNamePart(this string formattedstring, string value, Func<bool> testExpression) =>
            testExpression() == true ? $"{formattedstring}{value}" : formattedstring;
    }

    public static class StringFormatter1
    {
        public static string GetFormattedName(string productName, string productColor, string productClass, string cultivationType) =>
            productName
            .AddNamePart(productColor)
            .AddNamePart(productClass)
            .AddNamePart(" (BIO)", () => !string.IsNullOrEmpty(cultivationType) && cultivationType.Equals("biologic"));

        private static string AddNamePart(this string formattedstring, string value) =>
        !string.IsNullOrEmpty(value) ? $"{formattedstring}, {value}" : formattedstring;

        private static string AddNamePart(this string formattedstring, string value, Func<bool> testExpression) =>
            testExpression() == true ? $"{formattedstring}{value}" : formattedstring;
    }

    public static class OldStringFormatter
    {
        public static string GetFormattedName(string productName, string productColor, string productClass, string cultivationType)
        {
            if(!string.IsNullOrEmpty(productColor))
                productName += $", {productColor}";
            
            if(!string.IsNullOrEmpty(productClass))
                productName += $", {productClass}";

            if(!string.IsNullOrEmpty(cultivationType) && cultivationType == "biologic")
                productName += " (BIO)";

            return productName;
        }
    }
}
