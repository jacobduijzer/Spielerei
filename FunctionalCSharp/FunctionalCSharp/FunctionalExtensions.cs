using System;
using System.Collections.Generic;

namespace FunctionalCSharp
{
    public static class FunctionalExtensions
    {
        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> ts, 
            Func<T, bool> predicate)
        {
            foreach (T t in ts)
                if (predicate(t))
                    yield return t;
        }
    }
}
