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
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
