using System.Collections.Generic;
using System.Linq;

namespace Mollie.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Ensures enumerable is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> EnsureNotNull<T>(this IEnumerable<T> list)
        {
            return list ?? Enumerable.Empty<T>();
        }
    }
}
