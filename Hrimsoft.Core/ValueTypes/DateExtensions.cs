using System;

namespace Hrimsoft.Core.ValueTypes
{
    public static class DateExtensions
    {
        /// <summary> Converts Date to DateTime </summary>
        public static DateTime ToDateTime(this Date date) 
            => new DateTime(date.Year, date.Month, date.Day);
        
        /// <summary> Converts Date to DateTimeOffset </summary>
        public static DateTimeOffset ToDateTimeOffset(this Date date) 
            => new DateTimeOffset(date.Year, date.Month, date.Day, 0,0,0, TimeSpan.Zero);
        
        /// <summary> Converts Date to DateTimeOffset with a specific offset </summary>
        public static DateTimeOffset ToDateTimeOffset(this Date date, TimeSpan offset) 
            => new DateTimeOffset(date.Year, date.Month, date.Day, 0,0,0, offset);
    }
}