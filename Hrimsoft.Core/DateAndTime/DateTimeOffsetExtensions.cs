using System;
using Hrimsoft.Core.ValueObjects;

namespace Hrimsoft.Core.Extensions {
    /// <summary>
    /// Methods that extend DateTimeOffset functionality
    /// </summary>
    public static class DateTimeOffsetExtensions {
        /// <summary>
        /// Truncate DateTimeOffset to milliseconds, seconds, etc that is depends on TimeSpan 
        /// </summary>
        /// <param name="dateTime">date and time that must be truncated</param>
        /// <param name="timeSpan">a period to which it will truncate. If it is needed to cut all micro and nano seconds Time span should be 1 millisecond</param>
        public static DateTimeOffset Truncate(this DateTimeOffset dateTime, TimeSpan timeSpan) {
            if (timeSpan == TimeSpan.Zero)
                return dateTime;
            if (dateTime == DateTimeOffset.MinValue || dateTime == DateTimeOffset.MaxValue)
                return dateTime;
            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }

        /// <summary>
        /// Cut nano seconds from DateTimeOffset 
        /// </summary>
        /// <param name="dateTime">date and time that must be cut</param>
        public static DateTimeOffset TruncateToMicroseconds(this DateTimeOffset dateTime)
            => dateTime.Truncate(TimeSpan.FromMilliseconds(0.001));

        /// <summary>
        /// Cut micro and nano seconds from DateTimeOffset 
        /// </summary>
        /// <param name="dateTime">date and time that must be cut</param>
        public static DateTimeOffset TruncateToMilliseconds(this DateTimeOffset dateTime)
            => dateTime.Truncate(TimeSpan.FromMilliseconds(1));

        /// <summary>
        /// Cut micro-, nano- and milli- seconds from DateTimeOffset 
        /// </summary>
        /// <param name="dateTime">date and time that must be cut</param>
        public static DateTimeOffset TruncateToSeconds(this DateTimeOffset dateTime)
            => dateTime.Truncate(TimeSpan.FromSeconds(1));

        /// <summary> Converts DateTimeOffset to Date </summary>
        public static Date ToDate(this DateTimeOffset dateTimeOffset) => new Date(dateTimeOffset);

        public static bool IsTimeEquals(this DateTimeOffset one, DateTimeOffset another, TimePrecision precision = TimePrecision.Millisecond) {
            switch (precision) {
                case TimePrecision.Hour:
                    return one.Hour == another.Hour;
                case TimePrecision.Minute:
                    return one.Hour   == another.Hour &&
                           one.Minute == another.Minute;
                case TimePrecision.Second:
                    return one.Hour   == another.Hour   &&
                           one.Minute == another.Minute &&
                           one.Second == another.Second;
                case TimePrecision.Millisecond:
                    return one.Hour        == another.Hour   &&
                           one.Minute      == another.Minute &&
                           one.Second      == another.Second &&
                           one.Millisecond == another.Millisecond;
                default:
                    throw new ArgumentOutOfRangeException(nameof(precision), precision, null);
            }
        }
    }
}