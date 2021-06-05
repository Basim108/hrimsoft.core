using System;
using FluentAssertions;
using Hrimsoft.Core.ValueTypes;
using Xunit;

namespace Hrimsoft.Core.Tests.ValueTypes
{
    public class DateTests
    {
        [Fact]
        public void Date_Should_Be_Equal_To_DateTime()
        {
            (new Date(2021, 01, 01) == new DateTime(2021, 01, 01)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Greater_Than_DateTime()
        {
            (new Date(2021, 01, 02) > new DateTime(2021, 01, 01)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Less_Than_DateTime()
        {
            (new Date(2021, 01, 01) < new DateTime(2021, 01, 02)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Equal_To_DateTime_WithTime()
        {
            (new Date(2021, 01, 01) == new DateTime(2021, 01, 01, 23, 59, 59)).Should().Be(true);
        }

        [Fact]
        public void Date_Should_Be_Casted_From_DateTime()
        {
            var dateTime = new DateTime(2021, 02, 01);
            var date     = (Date) dateTime;
            date.Year.Should().Be(2021);
            date.Month.Should().Be(2);
            date.Day.Should().Be(1);
        }

        [Fact]
        public void DateTime_Should_Be_Casted_From_Date()
        {
            var date     = new Date(2021, 02, 01);
            var dateTime = (DateTime) date;
            dateTime.Year.Should().Be(2021);
            dateTime.Month.Should().Be(2);
            dateTime.Day.Should().Be(1);
        }

        [Fact]
        public void Date_Is_No_Bigger_Than_4_Bytes()
        {
            int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Date));
            (size <= 4).Should().Be(true);
        }
    }
}