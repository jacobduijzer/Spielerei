using System.Collections;
using System.Collections.Generic;

namespace FunctionalCSharp.Tests
{
    public class StringFormatterTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "strawberry", "red", "first class", "normal", "strawberry, red, first class" };
            yield return new object[] { "strawberry", "red", "first class", "biologic", "strawberry, red, first class (BIO)" };
            yield return new object[] { "strawberry", "", "first class", "biologic", "strawberry, first class (BIO)" };
            yield return new object[] { "strawberry", "", "", "biologic", "strawberry (BIO)" };
            yield return new object[] { "strawberry", "", "", "normal", "strawberry" };
            yield return new object[] { "strawberry", "red", "", "normal", "strawberry, red" };
            yield return new object[] { "strawberry", "red", "", "biologic", "strawberry, red (BIO)" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
