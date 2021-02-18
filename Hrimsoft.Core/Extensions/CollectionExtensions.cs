using System.Collections.Generic;

namespace Hrimsoft.Core.Extensions
{
    /// <summary>
    /// Extents IEnumerable interface
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Checks an enumerable instance for being null or not having any of items
        /// </summary>
        /// <returns>
        /// Returns true if the instance is null or there is no items at all.
        /// Otherwise, returns false
        /// </returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            if (source == null)
                return true;

            return source.Count == 0;
        }
        
        /// <summary>
        /// Checks an enumerable instance for being not null and having at least one item
        /// </summary>
        /// <returns>
        /// Returns true if the instance is not null and has at least one item.
        /// Otherwise, returns false
        /// </returns>
        public static bool IsNotEmpty<T>(this ICollection<T> source)
        {
            return source != null && source.Count > 0;
        }
    }
}