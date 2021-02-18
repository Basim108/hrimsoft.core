using System;

namespace Hrimsoft.Core.Extensions
{
    /// <summary>
    /// Методы расширения для типа int
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Создание DateTimeOffset из Unix timestamp и заданным смещением
        /// </summary>
        /// <param name="ts">Unix time stamp</param>
        /// <param name="offsetSeconds">часовая зона в секундах</param>
        public static DateTimeOffset ToDateTimeOffset(this int ts, int offsetSeconds)
        {
            return DateTimeOffset.FromUnixTimeSeconds(ts)
                .ToOffset(TimeSpan.FromSeconds(offsetSeconds));
        }
    }
}