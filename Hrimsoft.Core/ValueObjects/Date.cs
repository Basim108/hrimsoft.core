using System;
using System.Globalization;
using Hrimsoft.Core.Extensions;

namespace Hrimsoft.Core.ValueObjects
{
    /// <summary> Immutable structure represents date value without time </summary>
    public struct Date : IComparable<Date>
    {
        /// <summary>
        /// The year (1 through 65535).
        /// But be aware that in DateTime the year part has max value = 9999.
        /// </summary>
        public readonly ushort Year;

        /// <summary>
        /// The month (1 through 12).
        /// </summary>
        public readonly byte Month;

        /// <summary>
        /// The day (1 through the number of days in month).
        /// </summary>
        public readonly byte Day;

        /// <summary>Represents the smallest possible value of <see cref="T:Hrimsoft.Core.ValueObjects.Date"></see>. This field is read-only.</summary>
        public static readonly Date MinValue = new Date(DateTime.MinValue);

        /// <summary>Represents the largest possible value of <see cref="T:Hrimsoft.Core.ValueObjects.Date"></see>. This field is read-only.</summary>
        public static readonly Date MaxValue = new Date(DateTime.MaxValue);

        /// <summary>
        /// initial value 
        /// </summary>
        public Date(DateTime value)
        {
            Year  = (ushort) value.Year;
            Month = (byte) value.Month;
            Day   = (byte) value.Day;
        }

        /// <summary>
        /// initial value 
        /// </summary>
        public Date(DateTimeOffset value)
        {
            Year  = (ushort) value.Year;
            Month = (byte) value.Month;
            Day   = (byte) value.Day;
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.DateTime"></see> structure to the specified year, month, and day.</summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year">year</paramref> is less than 1 or greater than 9999.   -or-  <paramref name="month">month</paramref> is less than 1 or greater than 12.   -or-  <paramref name="day">day</paramref> is less than 1 or greater than the number of days in <paramref name="month">month</paramref>.</exception>
        public Date(ushort year, byte month, byte day)
        {
            Year  = year;
            Month = month;
            Day   = day;
            Validate(year, month, day);
        }
        
        /// <summary>Returns a new <see cref="T:Hrimsoft.Date"></see> that adds the specified number of days to the value of this instance.</summary>
        /// <param name="value">A number of whole and fractional days. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of days represented by <paramref name="value">value</paramref>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The resulting <see cref="T:Hrimsoft.Date"></see> is less than <see cref="F:System.DateTime.MinValue"></see> or greater than <see cref="F:Hrimsoft.Date.MaxValue"></see>.</exception>
        public Date AddDays(double value) =>
            value == 0 
                ? new Date(this.Year, this.Month, this.Day) 
                : this.ToDateTime().AddDays(value).ToDate();

        /// <summary>
        /// Validate date parts
        /// </summary>
        private void Validate(ushort year, byte month, byte day)
        {
            const string ARG_MUST_BE_LESS_THAN_N    = "Argument {0} must be less than {1}, but it is {2}";
            const string ARG_MUST_BE_GREATER_THAN_0 = "Argument {0} must be 1 or greater, but it is {1}";

            if (year < 1)
                throw new ArgumentOutOfRangeException(nameof(year), year, string.Format(ARG_MUST_BE_GREATER_THAN_0, nameof(year), year));
            if (year > 9999)
                throw new ArgumentOutOfRangeException(nameof(year), year, string.Format(ARG_MUST_BE_LESS_THAN_N, nameof(year), 9999, year));

            if (month < 1)
                throw new ArgumentOutOfRangeException(nameof(month), month, string.Format(ARG_MUST_BE_GREATER_THAN_0, nameof(month), month));
            if (month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), month, string.Format(ARG_MUST_BE_LESS_THAN_N, nameof(month), 12, month));

            if (day < 1)
                throw new ArgumentOutOfRangeException(nameof(day), day, string.Format(ARG_MUST_BE_GREATER_THAN_0, nameof(day), day));

            var sample      = new DateTime(year, month, 1);
            var daysInMonth = (sample.AddMonths(1) - sample).Days;
            if (day > daysInMonth)
                throw new ArgumentOutOfRangeException(nameof(day), day, string.Format(ARG_MUST_BE_LESS_THAN_N, nameof(day), daysInMonth, day));
        }

        /// <summary>Converts the value of the current <see cref="T:System.DateTime"></see> object to its equivalent string representation using the specified format and the formatting conventions of the current culture.</summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <see cref="T:System.DateTime"></see> object as specified by <paramref name="format">format</paramref>.</returns>
        /// <exception cref="T:System.FormatException">The length of <paramref name="format">format</paramref> is 1, and it is not one of the format specifier characters defined for <see cref="T:System.Globalization.DateTimeFormatInfo"></see>.   -or-  <paramref name="format">format</paramref> does not contain a valid custom format pattern.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The date and time is outside the range of dates supported by the calendar used by the current culture.</exception>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>Converts the value of the current <see cref="T:System.DateTime"></see> object to its equivalent string representation using the specified format and culture-specific format information.</summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="T:System.DateTime"></see> object as specified by <paramref name="format">format</paramref> and <paramref name="provider">provider</paramref>.</returns>
        /// <exception cref="T:System.FormatException">The length of <paramref name="format">format</paramref> is 1, and it is not one of the format specifier characters defined for <see cref="T:System.Globalization.DateTimeFormatInfo"></see>.   -or-  <paramref name="format">format</paramref> does not contain a valid custom format pattern.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The date and time is outside the range of dates supported by the calendar used by <paramref name="provider">provider</paramref>.</exception>
        public string ToString(string format, IFormatProvider provider)
        {
            return new DateTime(Year, Month, Day).ToString(format, provider);
        }

        public int CompareTo(Date other)
        {
            if (this < other)
                return -1;
            return this > other ? 1 : 0;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var another = obj is Date date ? date : default;
            return this == another;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked {
                int hashCode = Year;
                hashCode = (hashCode * 397) ^ Month;
                hashCode = (hashCode * 397) ^ Day;
                return hashCode;
            }
        }

        #region compare operators with Date and Date

        /// <summary> Compares two dates </summary>
        public static bool operator ==(Date dt1, Date dt2)
        {
            return dt1.Year  == dt2.Year  &&
                   dt1.Month == dt2.Month &&
                   dt1.Day   == dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator !=(Date dt1, Date dt2)
        {
            return !(dt1 == dt2);
        }

        /// <summary> Compares two dates </summary>
        public static bool operator >=(Date dt1, Date dt2)
        {
            if (dt1.Year < dt2.Year)
                return false;
            if (dt1.Year > dt2.Year)
                return true;
            if (dt1.Month < dt2.Month)
                return false;
            if (dt1.Month > dt2.Month)
                return true;
            return dt1.Day > dt2.Day || dt1.Day == dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator <=(Date dt1, Date dt2)
        {
            if (dt1.Year < dt2.Year)
                return true;
            if (dt1.Year > dt2.Year)
                return false;
            if (dt1.Month < dt2.Month)
                return true;
            if (dt1.Month > dt2.Month)
                return false;
            return dt1.Day < dt2.Day || dt1.Day == dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator >(Date dt1, Date dt2)
        {
            if (dt1.Year < dt2.Year)
                return false;
            if (dt1.Year > dt2.Year)
                return true;
            if (dt1.Month < dt2.Month)
                return false;
            if (dt1.Month > dt2.Month)
                return true;
            return dt1.Day > dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator <(Date dt1, Date dt2)
        {
            if (dt1.Year < dt2.Year)
                return true;
            if (dt1.Year > dt2.Year)
                return false;
            if (dt1.Month < dt2.Month)
                return true;
            if (dt1.Month > dt2.Month)
                return false;
            return dt1.Day < dt2.Day;
        }

        /// <summary> Compares two nullable dates </summary>
        public static bool operator ==(Date? dt1, Date? dt2)
        {
            if (dt1.HasValue != dt2.HasValue)
                return false;
            if (!dt1.HasValue)
                return true;

            return dt1.Value.Year  == dt2.Value.Year  &&
                   dt1.Value.Month == dt2.Value.Month &&
                   dt1.Value.Day   == dt2.Value.Day;
        }

        /// <summary> Compares two nullable dates </summary>
        public static bool operator !=(Date? dt1, Date? dt2)
        {
            return !(dt1 == dt2);
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator >(Date? dt1, Date dt2)
        {
            return dt1.HasValue && dt1.Value > dt2;
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator <(Date? dt1, Date dt2)
        {
            return dt1.HasValue && dt1.Value < dt2;
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator >=(Date? dt1, Date dt2)
        {
            if (dt1.HasValue)
                return dt1.Value >= dt2;
            // null считаем равным Date.MinValue
            return dt2 == Date.MinValue;
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator <=(Date? dt1, Date dt2)
        {
            if (dt1.HasValue)
                return dt1.Value <= dt2;
            return true;
        }

        #endregion

        #region compare operators with Date and DateTime

        /// <summary> Compares two dates </summary>
        public static bool operator ==(Date dt1, DateTime dt2)
        {
            return dt1.Year  == dt2.Year  &&
                   dt1.Month == dt2.Month &&
                   dt1.Day   == dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator !=(Date dt1, DateTime dt2)
        {
            return !(dt1 == dt2);
        }

        /// <summary> Compares two dates </summary>
        public static bool operator >(Date dt1, DateTime dt2)
        {
            if (dt1.Year < dt2.Year)
                return false;
            if (dt1.Year > dt2.Year)
                return true;
            if (dt1.Month < dt2.Month)
                return false;
            if (dt1.Month > dt2.Month)
                return true;
            return dt1.Day > dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator <(Date dt1, DateTime dt2)
        {
            if (dt1.Year < dt2.Year)
                return true;
            if (dt1.Year > dt2.Year)
                return false;
            if (dt1.Month < dt2.Month)
                return true;
            if (dt1.Month > dt2.Month)
                return false;
            return dt1.Day < dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator >=(Date dt1, DateTime dt2)
        {
            if (dt1.Year < dt2.Year)
                return false;
            if (dt1.Year > dt2.Year)
                return true;
            if (dt1.Month < dt2.Month)
                return false;
            if (dt1.Month > dt2.Month)
                return true;
            return dt1.Day > dt2.Day || dt1.Day == dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator <=(Date dt1, DateTime dt2)
        {
            if (dt1.Year < dt2.Year)
                return true;
            if (dt1.Year > dt2.Year)
                return false;
            if (dt1.Month < dt2.Month)
                return true;
            if (dt1.Month > dt2.Month)
                return false;
            return dt1.Day < dt2.Day || dt1.Day == dt2.Day;
        }

        /// <summary> Compares two nullable dates </summary>
        public static bool operator ==(DateTime? dt1, Date? dt2)
        {
            return dt2 == dt1;
        }

        /// <summary> Compares two nullable dates </summary>
        public static bool operator !=(DateTime? dt1, Date? dt2)
        {
            return !(dt2 == dt1);
        }

        /// <summary> Compares two nullable dates </summary>
        public static bool operator ==(Date? dt1, DateTime? dt2)
        {
            if (dt1.HasValue != dt2.HasValue)
                return false;
            if (!dt1.HasValue)
                return true;

            return dt1.Value.Year  == dt2.Value.Year  &&
                   dt1.Value.Month == dt2.Value.Month &&
                   dt1.Value.Day   == dt2.Value.Day;
        }

        /// <summary> Compares two nullable dates </summary>
        public static bool operator !=(Date? dt1, DateTime? dt2)
        {
            return !(dt1 == dt2);
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator >(Date? dt1, DateTime dt2)
        {
            return dt1.HasValue && dt1.Value > dt2;
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator <(Date? dt1, DateTime dt2)
        {
            return dt1.HasValue && dt1.Value < dt2;
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator >=(Date? dt1, DateTime dt2)
        {
            if (dt1.HasValue)
                return dt1.Value >= dt2;
            // null считаем равным DateTime.MinValue
            return dt2 == DateTime.MinValue;
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator <=(Date? dt1, DateTime dt2)
        {
            if (dt1.HasValue)
                return dt1.Value <= dt2;
            return true;
        }

        #endregion

        #region compare operators with Date and DateTimeOffset

        /// <summary> Compares two dates </summary>
        public static bool operator ==(Date dt1, DateTimeOffset dt2)
        {
            return dt1.Year  == dt2.Year  &&
                   dt1.Month == dt2.Month &&
                   dt1.Day   == dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator !=(Date dt1, DateTimeOffset dt2)
        {
            return !(dt1 == dt2);
        }

        /// <summary> Compares two dates </summary>
        public static bool operator >(Date dt1, DateTimeOffset dt2)
        {
            if (dt1.Year < dt2.Year)
                return false;
            if (dt1.Year > dt2.Year)
                return true;
            if (dt1.Month < dt2.Month)
                return false;
            if (dt1.Month > dt2.Month)
                return true;
            return dt1.Day > dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator <(Date dt1, DateTimeOffset dt2)
        {
            if (dt1.Year < dt2.Year)
                return true;
            if (dt1.Year > dt2.Year)
                return false;
            if (dt1.Month < dt2.Month)
                return true;
            if (dt1.Month > dt2.Month)
                return false;
            return dt1.Day < dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator >=(Date dt1, DateTimeOffset dt2)
        {
            if (dt1.Year < dt2.Year)
                return false;
            if (dt1.Year > dt2.Year)
                return true;
            if (dt1.Month < dt2.Month)
                return false;
            if (dt1.Month > dt2.Month)
                return true;
            return dt1.Day > dt2.Day || dt1.Day == dt2.Day;
        }

        /// <summary> Compares two dates </summary>
        public static bool operator <=(Date dt1, DateTimeOffset dt2)
        {
            if (dt1.Year < dt2.Year)
                return true;
            if (dt1.Year > dt2.Year)
                return false;
            if (dt1.Month < dt2.Month)
                return true;
            if (dt1.Month > dt2.Month)
                return false;
            return dt1.Day < dt2.Day || dt1.Day == dt2.Day;
        }

        /// <summary> Compares two nullable dates </summary>
        public static bool operator ==(DateTimeOffset? dt1, Date? dt2)
        {
            return dt2 == dt1;
        }

        /// <summary> Compares two nullable dates </summary>
        public static bool operator !=(DateTimeOffset? dt1, Date? dt2)
        {
            return !(dt2 == dt1);
        }

        /// <summary> Compares two nullable dates </summary>
        public static bool operator ==(Date? dt1, DateTimeOffset? dt2)
        {
            if (dt1.HasValue != dt2.HasValue)
                return false;
            if (!dt1.HasValue)
                return true;

            return dt1.Value.Year  == dt2.Value.Year  &&
                   dt1.Value.Month == dt2.Value.Month &&
                   dt1.Value.Day   == dt2.Value.Day;
        }

        /// <summary> Compares two nullable dates </summary>
        public static bool operator !=(Date? dt1, DateTimeOffset? dt2)
        {
            return !(dt1 == dt2);
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator >(Date? dt1, DateTimeOffset dt2)
        {
            return dt1.HasValue && dt1.Value > dt2;
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator <(Date? dt1, DateTimeOffset dt2)
        {
            return dt1.HasValue && dt1.Value < dt2;
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator >=(Date? dt1, DateTimeOffset dt2)
        {
            if (dt1.HasValue)
                return dt1.Value >= dt2;
            // null считаем равным DateTimeOffset.MinValue
            return dt2 == DateTimeOffset.MinValue;
        }

        /// <summary> Compares one nullable date </summary>
        public static bool operator <=(Date? dt1, DateTimeOffset dt2)
        {
            if (dt1.HasValue)
                return dt1.Value <= dt2;
            return true;
        }

        #endregion
    }
}