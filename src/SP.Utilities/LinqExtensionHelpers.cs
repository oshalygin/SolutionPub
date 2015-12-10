using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Utilities
{
    public static class LinqExtensionHelpers
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            var availableKeys = new HashSet<TKey>();
            return source
                .Where(element => availableKeys.Add(keySelector(element)));
        }
    }
}