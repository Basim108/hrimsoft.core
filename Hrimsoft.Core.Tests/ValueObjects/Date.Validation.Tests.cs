using System;
using FluentAssertions;
using Hrimsoft.Core.ValueObjects;
using Xunit;

namespace Hrimsoft.Core.Tests.ValueObjects
{
    public class DateValidationTests
    {
        [Fact]
        public void Should_validate_small_year()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Date(0, 1, 1));
            ex.ParamName.Should().Be("year");
        }

        [Fact]
        public void Should_validate_too_big_year()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Date(10000, 1, 1));
            ex.ParamName.Should().Be("year");
        }

        [Fact]
        public void Should_validate_small_month()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Date(1, 0, 1));
            ex.ParamName.Should().Be("month");
        }

        [Fact]
        public void Should_validate_too_big_month()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Date(1, 13, 1));
            ex.ParamName.Should().Be("month");
        }

        [Fact]
        public void Should_validate_small_day()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Date(1, 1, 0));
            ex.ParamName.Should().Be("day");
        }

        [Fact]
        public void Should_validate_too_big_day()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Date(1, 1, 50));
            ex.ParamName.Should().Be("day");
        }

        [Fact]
        public void Should_validate_that_in_jenuary_31_days()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Date(2019, 1, 32));
            ex.ParamName.Should().Be("day");
        }

        [Fact]
        public void Should_validate_that_in_february_28_days()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Date(2019, 2, 29));
            ex.ParamName.Should().Be("day");
        }

        [Fact]
        public void Leap_year_should_pass_validation()
        {
            var date = new Date(2000, 2, 29);
            date.Should().NotBeNull();
        }
    }
}