using System;
using FluentAssertions;
using Hrimsoft.Core.Extensions;
using Hrimsoft.Core.ValueObjects;
using Xunit;

namespace Hrimsoft.Core.Tests.ValueObjects
{
    public class DateConversionTests
    {
        [Fact]
        public void ToDate_Should_Cast_DateTimeOffset()
        {
            var dateTimeOffset = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            var date           = dateTimeOffset.ToDate();
            date.Year.Should().Be(2021);
            date.Month.Should().Be(2);
            date.Day.Should().Be(1);
        }

        [Fact]
        public void ToDate_Should_Cast_DateTime()
        {
            var dateTime = new DateTime(2021, 02, 01);
            var date     = dateTime.ToDate();
            date.Year.Should().Be(2021);
            date.Month.Should().Be(2);
            date.Day.Should().Be(1);
        }

        [Fact]
        public void ToDateTime_Should_Cast_Date()
        {
            var date     = new Date(2021, 02, 01);
            var dateTime = date.ToDateTime();
            dateTime.Year.Should().Be(2021);
            dateTime.Month.Should().Be(2);
            dateTime.Day.Should().Be(1);
        }
        
        [Fact]
        public void ToDateTimeOffset_Should_Cast_Date()
        {
            var date     = new Date(2021, 02, 01);
            var dateTime = date.ToDateTimeOffset();
            dateTime.Year.Should().Be(2021);
            dateTime.Month.Should().Be(2);
            dateTime.Day.Should().Be(1);
        }
        
        [Fact]
        public void ToDateTimeOffset_Should_Cast_Date_With_Offset()
        {
            var date     = new Date(2021, 02, 01);
            var dateTime = date.ToDateTimeOffset(TimeSpan.FromHours(3));
            dateTime.Year.Should().Be(2021);
            dateTime.Month.Should().Be(2);
            dateTime.Day.Should().Be(1);
            dateTime.Offset.Should().Be(TimeSpan.FromHours(3));
        }

        [Fact]
        public void ToString_Given_SortFormat_Returns_DateTime_ToString()
        {
            var date     = new Date(2021, 02, 01);
            var dateTime = new DateTime(2021, 02, 01);
            date.ToString("O").Should().Be(dateTime.ToString("O"));
        }

        [Fact]
        public void ToString_Given_CustomFormat_Returns_DateTime_ToString()
        {
            var date     = new Date(2021, 02, 01);
            var dateTime = new DateTime(2021, 02, 01);
            date.ToString("dd-MM-yyyy").Should().Be("01-02-2021");
        }
    }
}