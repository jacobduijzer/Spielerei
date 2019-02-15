using System;

namespace FunctionalCSharp
{
    public static class StringFormatter2
    {
        public static string GetFormattedName(string productName, string productColor, string productClass, string cultivationType) =>
            productName
                .AppendPart($", {productColor}", () => !string.IsNullOrEmpty(productColor))
                .AppendPart($", {productClass}", () => !string.IsNullOrEmpty(productClass))
                .AppendPart(" (BIO)", () => !string.IsNullOrEmpty(cultivationType) && cultivationType.Equals("biologic"));

        private static string AppendPart(this string inputString, string value, Func<bool> testExpression) =>
            testExpression() == true ? $"{inputString}{value}" : inputString;
    }

    public static class StringFormatter1
    {
        public static string GetFormattedName(string productName, string productColor, string productClass, string cultivationType) =>
            productName
                .AppendPart(productColor)
                .AppendPart(productClass)
                .AppendPart(" (BIO)", () => !string.IsNullOrEmpty(cultivationType) && cultivationType.Equals("biologic"));

        private static string AppendPart(this string inputString, string value) =>
            !string.IsNullOrEmpty(value) ? $"{inputString}, {value}" : inputString;

        private static string AppendPart(this string inputString, string value, Func<bool> testExpression) =>
            testExpression() == true ? $"{inputString}{value}" : inputString;
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
