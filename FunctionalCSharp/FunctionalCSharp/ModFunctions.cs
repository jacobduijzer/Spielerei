using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalCSharp
{
    public class ModFunctions
    {
        private Func<int, bool> isMod2 = x => x % 2 == 0;
        private Func<int, bool> isNotMod2 = x => x % 2 != 0;

        public IEnumerable<int> GetEvenNumbers(IEnumerable<int> list) =>
            list.Where(isMod2);

        public IEnumerable<int> GetUnevenNumbers(IEnumerable<int> list) =>
            list.Where(isNotMod2);
    }
}
