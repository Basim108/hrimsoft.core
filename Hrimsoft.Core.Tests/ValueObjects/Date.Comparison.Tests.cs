using System;
using FluentAssertions;
using Hrimsoft.Core.ValueObjects;
using Xunit;

namespace Hrimsoft.Core.Tests.ValueObjects
{
    public class DateComparisonTests
    {
        [Fact]
        public void Date_Should_Be_Equal_To_DateTime()
        {
            (new Date(2021, 01, 01) == new DateTime(2021, 01, 01)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Greater_Than_DateTime_By_Day()
        {
            (new Date(2021, 01, 02) > new DateTime(2021, 01, 01)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Greater_Than_DateTime_By_Month()
        {
            (new Date(2021, 02, 01) > new DateTime(2021, 01, 20)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Greater_Than_DateTime_By_Year()
        {
            (new Date(2022, 01, 01) > new DateTime(2021, 05, 20)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Less_Than_DateTime_By_Day()
        {
            (new Date(2021, 01, 01) < new DateTime(2021, 01, 02)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Less_Than_DateTime_By_Month()
        {
            (new Date(2021, 01, 05) < new DateTime(2021, 02, 01)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Less_Than_DateTime_By_Year()
        {
            (new Date(2020, 10, 20) < new DateTime(2021, 01, 01)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Equal_To_DateTime_WithTime()
        {
            (new Date(2021, 01, 01) == new DateTime(2021, 01, 01, 23, 59, 59)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Equal_To_DateTimeOffset()
        {
            (new Date(2021, 01, 01) == new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))
               .Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Greater_Than_DateTimeOffset_By_Day()
        {
            (new Date(2021, 01, 02) > new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))
               .Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Greater_Than_DateTimeOffset_By_Month()
        {
            (new Date(2021, 02, 01) > new DateTimeOffset(2021, 1, 5, 0, 0, 0, TimeSpan.Zero))
               .Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Greater_Than_DateTimeOffset_By_Year()
        {
            (new Date(2021, 01, 01) > new DateTimeOffset(2020, 10, 20, 0, 0, 0, TimeSpan.Zero))
               .Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Less_Than_DateTimeOffset_By_Day()
        {
            (new Date(2021, 01, 01) < new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero))
               .Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Less_Than_DateTimeOffset_By_Month()
        {
            (new Date(2021, 1, 20) < new DateTimeOffset(2021, 2, 1, 0, 0, 0, TimeSpan.Zero))
               .Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Less_Than_DateTimeOffset_By_Year()
        {
            (new Date(2020, 12, 31) < new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))
               .Should().Be(true);
        }

        [Fact]
        public void Nullable_Date_Should_Be_LessOrEqual_Than_DateTimeOffset()
        {
            Date? dt1 = new Date(2019, 9, 17);
            var   dt2 = new DateTimeOffset(2019, 9, 18, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.True(dt1 <= dt2);

            dt1 = new Date(2019, 9, 18);
            dt2 = new DateTimeOffset(2019, 9, 18, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.True(dt1 <= dt2);

            dt1 = new Date(2020, 9, 18);
            dt2 = new DateTimeOffset(2019, 9, 18, 12, 0, 0, TimeSpan.FromHours(3));
            Assert.False(dt1 <= dt2);

            dt1 = new Date(2019, 10, 18);
            dt2 = new DateTimeOffset(2019, 9, 18, 12, 0, 0, TimeSpan.FromHours(3));
            Assert.False(dt1 <= dt2);

            dt1 = new Date(2019, 9, 19);
            dt2 = new DateTimeOffset(2019, 9, 18, 12, 0, 0, TimeSpan.FromHours(3));
            Assert.False(dt1 <= dt2);

            dt1 = null;
            dt2 = new DateTimeOffset(2019, 9, 18, 12, 0, 0, TimeSpan.FromHours(3));
            Assert.True(dt1 <= dt2);

            Assert.True(dt1 <= DateTimeOffset.MinValue);
        }

        [Fact]
        public void Nullable_Date_Should_Be_LessOrEqual_Than_Datetime()
        {
            Date? dt1 = new Date(2019, 9, 17);
            var   dt2 = new DateTime(2019, 9, 18);
            Assert.True(dt1 <= dt2);

            dt1 = new Date(2019, 9, 18);
            dt2 = new DateTime(2019, 9, 18);
            Assert.True(dt1 <= dt2);

            dt1 = new Date(2020, 9, 18);
            dt2 = new DateTime(2019, 9, 18);
            Assert.False(dt1 <= dt2);

            dt1 = new Date(2019, 10, 18);
            dt2 = new DateTime(2019, 9, 18);
            Assert.False(dt1 <= dt2);

            dt1 = new Date(2019, 9, 19);
            dt2 = new DateTime(2019, 9, 18);
            Assert.False(dt1 <= dt2);

            dt1 = null;
            dt2 = new DateTime(2019, 9, 18);
            Assert.True(dt1 <= dt2);

            Assert.True(dt1 <= DateTime.MinValue);
        }

        [Fact]
        public void Should_compare_non_equality_of_dates()
        {
            var dt1 = new Date(2019, 9, 18);
            var dt2 = new Date(2019, 9, 18);
            Assert.False(dt1 != dt2);

            dt1 = new Date(2020, 9, 18);
            dt2 = new Date(2019, 9, 18);
            Assert.True(dt1 != dt2);

            dt1 = new Date(2019, 8, 18);
            dt2 = new Date(2019, 9, 18);
            Assert.True(dt1 != dt2);

            dt1 = new Date(2019, 9, 17);
            dt2 = new Date(2019, 9, 18);
            Assert.True(dt1 != dt2);
        }

        [Fact]
        public void Should_compare_non_equality_of_date_and_datetime()
        {
            var dt1 = new Date(2019, 9, 18);
            var dt2 = new DateTime(2019, 9, 18);
            Assert.False(dt1 != dt2);

            dt1 = new Date(2019, 9, 19);
            dt2 = new DateTime(2019, 9, 18);
            Assert.True(dt1 != dt2);

            dt1 = new Date(2019, 10, 18);
            dt2 = new DateTime(2019, 9, 18);
            Assert.True(dt1 != dt2);

            dt1 = new Date(2020, 9, 18);
            dt2 = new DateTime(2019, 9, 18);
            Assert.True(dt1 != dt2);
        }

        [Fact]
        public void Should_compare_non_equality_of_date_and_datetime_offset()
        {
            var dt1 = new Date(2019, 9, 18);
            var dt2 = new DateTimeOffset(2019, 9, 18, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.False(dt1 != dt2);

            dt1 = new Date(2019, 9, 18);
            dt2 = new DateTimeOffset(2020, 9, 18, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.True(dt1 != dt2);

            dt1 = new Date(2019, 9, 18);
            dt2 = new DateTimeOffset(2019, 8, 18, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.True(dt1 != dt2);

            dt1 = new Date(2019, 9, 18);
            dt2 = new DateTimeOffset(2019, 9, 19, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.True(dt1 != dt2);
        }

        [Fact]
        public void Should_compare_non_equality_of_date_and_datetime_despite_time()
        {
            var dt1 = new Date(2019, 9, 18);
            var dt2 = new DateTime(2019, 9, 18, 12, 0, 0);
            Assert.False(dt1 != dt2);

            dt1 = new Date(2019, 9, 19);
            dt2 = new DateTime(2019, 9, 18, 12, 0, 0);
            Assert.True(dt1 != dt2);

            dt1 = new Date(2019, 10, 18);
            dt2 = new DateTime(2019, 9, 18, 12, 0, 0);
            Assert.True(dt1 != dt2);

            dt1 = new Date(2020, 9, 18);
            dt2 = new DateTime(2019, 9, 18, 12, 0, 0);
            Assert.True(dt1 != dt2);
        }

        [Fact]
        public void Should_compare_equality_of_nullable_dates()
        {
            Date? dt1 = new Date(2019, 9, 18);
            Date? dt2 = new Date(2019, 9, 18);
            Assert.True(dt1 == dt2);

            dt1 = new Date(2020, 9, 18);
            dt2 = new Date(2019, 9, 18);
            Assert.False(dt1 == dt2);

            dt1 = new Date(2019, 8, 18);
            dt2 = new Date(2019, 9, 18);
            Assert.False(dt1 == dt2);

            dt1 = new Date(2019, 9, 17);
            dt2 = new Date(2019, 9, 18);
            Assert.False(dt1 == dt2);

            dt1 = null;
            dt2 = new Date(2019, 9, 18);
            Assert.False(dt1 == dt2);

            dt1 = new Date(2019, 9, 17);
            dt2 = null;
            Assert.False(dt1 == dt2);

            dt1 = null;
            dt2 = null;
            Assert.True(dt1 == dt2);
        }

        [Fact]
        public void Nullable_Date_Should_Be_Equal_To_DateTimeOffset_Despite_Time()
        {
            Date?           dt1 = new Date(2019, 9, 18);
            DateTimeOffset? dt2 = new DateTimeOffset(2019, 9, 18, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.True(dt1 == dt2);

            dt1 = new Date(2019, 9, 18);
            dt2 = new DateTimeOffset(2020, 9, 18, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.False(dt1 == dt2);

            dt1 = new Date(2019, 9, 18);
            dt2 = new DateTimeOffset(2019, 8, 18, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.False(dt1 == dt2);

            dt1 = new Date(2019, 9, 18);
            dt2 = new DateTimeOffset(2019, 9, 19, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.False(dt1 == dt2);

            dt1 = null;
            dt2 = new DateTimeOffset(2019, 9, 19, 23, 59, 21, TimeSpan.FromHours(3));
            Assert.False(dt1 == dt2);

            dt1 = new Date(2019, 9, 17);
            dt2 = null;
            Assert.False(dt1 == dt2);

            dt1 = null;
            dt2 = null;
            Assert.True(dt1 == dt2);
        }

        [Fact]
        public void Nullable_Date_Should_Be_Equal_To_DateTime_Despite_Time()
        {
            Date?     dt1 = new Date(2019, 9, 18);
            DateTime? dt2 = new DateTime(2019, 9, 18, 12, 0, 0);
            Assert.True(dt1 == dt2);

            dt1 = new Date(2019, 9, 19);
            dt2 = new DateTime(2019, 9, 18, 12, 0, 0);
            Assert.False(dt1 == dt2);

            dt1 = new Date(2019, 10, 18);
            dt2 = new DateTime(2019, 9, 18, 12, 0, 0);
            Assert.False(dt1 == dt2);

            dt1 = new Date(2020, 9, 18);
            dt2 = new DateTime(2019, 9, 18, 12, 0, 0);
            Assert.False(dt1 == dt2);

            dt1 = null;
            dt2 = new DateTime(2019, 9, 19, 23, 59, 21);
            Assert.False(dt1 == dt2);

            dt1 = new Date(2019, 9, 17);
            dt2 = null;
            Assert.False(dt1 == dt2);

            dt1 = null;
            dt2 = null;
            Assert.True(dt1 == dt2);
        }

        [Fact]
        public void Nullable_Date_Should_Be_LessOrEqual_Than_Date()
        {
            Date? dt1 = new Date(2019, 9, 17);
            var   dt2 = new Date(2019, 9, 18);
            Assert.True(dt1 <= dt2);

            dt1 = new Date(2019, 9, 18);
            dt2 = new Date(2019, 9, 18);
            Assert.True(dt1 <= dt2);

            dt1 = new Date(2020, 9, 18);
            dt2 = new Date(2019, 9, 18);
            Assert.False(dt1 <= dt2);

            dt1 = new Date(2019, 10, 18);
            dt2 = new Date(2019, 9, 18);
            Assert.False(dt1 <= dt2);

            dt1 = new Date(2019, 9, 19);
            dt2 = new Date(2019, 9, 18);
            Assert.False(dt1 <= dt2);

            dt1 = null;
            dt2 = new Date(2019, 9, 18);
            Assert.True(dt1 <= dt2);

            Assert.True(dt1 <= Date.MinValue);
        }
    }
}