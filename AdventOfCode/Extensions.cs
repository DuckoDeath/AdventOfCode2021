using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public static class Extensions
    {
        public static IEnumerable<TResult> SelectWithPrevious<TSource, TResult>
        (this IEnumerable<TSource> source,
         Func<TSource, TSource, TResult> projection)
        {
            using (var iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                TSource previous = iterator.Current;
                while (iterator.MoveNext())
                {
                    yield return projection(previous, iterator.Current);
                    previous = iterator.Current;
                }
            }
        }

        public static IEnumerable<TResult> SelectWithPreviousQuad<TSource, TResult>
        (this IEnumerable<TSource> source,
         Func<TSource, TSource, TSource, TSource, TResult> projection)
        {
            using (var iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                TSource one = iterator.Current;
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                TSource two = iterator.Current;
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                TSource three = iterator.Current;
                while (iterator.MoveNext())
                {
                    yield return projection(one, two, three, iterator.Current);
                    one = two;
                    two = three;
                    three = iterator.Current;
                }
            }
        }
    }
}
