using System.Collections.Generic;

namespace BookFast.Api.Infrastructure.JwtBearer
{
    internal static class Extensions
    {
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            foreach (var source in first)
                yield return source;
            foreach (var source in second)
                yield return source;
        }
    }
}