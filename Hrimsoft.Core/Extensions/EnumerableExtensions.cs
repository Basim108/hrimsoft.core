using System.Collections.Generic;
using System.Linq;

namespace Hrimsoft.Core.Extensions
{
    /// <summary>
    /// Extents IEnumerable interface
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Checks an enumerable instance for being null or not having any of items
        /// </summary>
        /// <returns>
        /// Returns true if the instance is null or there is no items at all.
        /// Otherwise, returns false
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return true;

            return !source.Any();
        }
        
        /// <summary>
        /// Checks an enumerable instance for being not null and having at least one item
        /// </summary>
        /// <returns>
        /// Returns true if the instance is not null and has at least one item.
        /// Otherwise, returns false
        /// </returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }
    }
}