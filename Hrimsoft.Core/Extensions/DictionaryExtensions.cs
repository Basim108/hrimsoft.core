using System;
using System.Collections.Generic;

namespace Hrimsoft.Core.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Getting a value from a dictionary by a key
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue">In case there is no key in the dictionary this argument will be returned.</param>
        /// <returns>Returns a value from dictionary or a <paramref name="defaultValue"/></returns>
        /// <exception cref="ArgumentNullException">a dictionary must not be null</exception>
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            return dictionary.TryGetValue(key, out var value)
                       ? value
                       : defaultValue;
        }
    }
}