using System;
using System.Collections.Generic;

namespace FunctionalCSharp
{
    public static class FunctionalExtensions
    {
        public static IEnumerable<T> Filter<T>(
            this IEnumerable<T> items, 
            Func<T, bool> predicate)
        {
            foreach (T item in items)
                if (predicate(item))
                    yield return item;
        }
    }
}
