using System;
using System.Collections.Generic;
using System.Linq;

namespace Commandable.Core
{
    public static class Enumerable2
    {
        public static IEnumerable<Tuple<TFirst, TSecond>> ZipForFirst<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            var enumerator1 = first.GetEnumerator();
            var enumerator2 = second.GetEnumerator();

            while (enumerator1.MoveNext())
                yield return Tuple.Create(enumerator1.Current, enumerator2.MoveNext() ? enumerator2.Current : default(TSecond));
        }
    }
}
