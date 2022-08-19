using System;
using Hrimsoft.Core.ValueObjects;

namespace Hrimsoft.Core.Extensions
{
    /// <summary>
    /// Methods that extend DateTime functionality
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Truncate DateTime to milliseconds, seconds, etc that is depends on TimeSpan 
        /// </summary>
        /// <param name="dateTime">date and time that must be truncated</param>
        /// <param name="timeSpan">a period to which it will truncate. If it is needed to cut all micro and nano seconds Time span should be 1 millisecond</param>
        public static DateTime Truncate(this DateTime dateTime, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero)
                return dateTime;
            if (dateTime == DateTime.MinValue || dateTime == DateTime.MaxValue) 
                return dateTime; 
            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }
        
        /// <summary>
        /// Cut nano seconds from DateTime 
        /// </summary>
        /// <param name="dateTime">date and time that must be cut</param>
        public static DateTime TruncateToMicroseconds(this DateTime dateTime) 
            => dateTime.Truncate(TimeSpan.FromMilliseconds(0.001));
        
        /// <summary>
        /// Cut micro and nano seconds from DateTime 
        /// </summary>
        /// <param name="dateTime">date and time that must be cut</param>
        public static DateTime TruncateToMilliseconds(this DateTime dateTime) 
            => dateTime.Truncate(TimeSpan.FromMilliseconds(1));

        /// <summary>
        /// Cut micro-, nano- and milli- seconds from DateTime 
        /// </summary>
        /// <param name="dateTime">date and time that must be cut</param>
        public static DateTime TruncateToSeconds(this DateTime dateTime) 
            => dateTime.Truncate(TimeSpan.FromSeconds(1));

        /// <summary> Converts DateTime to Date </summary>
        public static Date ToDate(this DateTime dateTime) => new Date(dateTime);
    }
}