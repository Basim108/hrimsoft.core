using System;
using FluentAssertions;
using FluentAssertions.Extensions;
using Hrimsoft.Core.Extensions;
using Xunit;

namespace Hrimsoft.Core.Tests.DateAndTime {
    public class DateTimeOffsetExtensionTests {
        [Fact]
        public void Truncate_Should_Cut_To_Milliseconds() {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, 20, TimeSpan.Zero);
            expected.AddMilliseconds(0.3)
                    .Truncate(TimeSpan.FromMilliseconds(1))
                    .Should().Be(expected);
        }

        [Fact]
        public void Truncate_Should_Cut_To_Seconds() {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            expected.AddMilliseconds(20)
                    .Truncate(TimeSpan.FromSeconds(10))
                    .Should().Be(expected);
        }

        [Fact]
        public void Truncate_Should_Cut_To_Minutes() {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            expected.AddSeconds(20.33)
                    .Truncate(TimeSpan.FromMinutes(1))
                    .Should().Be(expected);
        }

        [Fact]
        public void Truncate_Should_Cut_To_Hours() {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            expected.AddMinutes(20.33)
                    .Truncate(TimeSpan.FromHours(1))
                    .Should().Be(expected);
        }

        [Fact]
        public void TruncateToMilliseconds_Should_Cut_To_Milliseconds() {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, 20, TimeSpan.Zero);
            expected.AddMilliseconds(0.3)
                    .TruncateToMilliseconds()
                    .Should().Be(expected);
        }

        [Fact]
        public void TruncateToSeconds_Should_Cut_To_Seconds() {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            expected.AddMilliseconds(20)
                    .TruncateToSeconds()
                    .Should().Be(expected);
        }

        [Fact]
        public void TruncateToMicro_Should_Cut_To_Microseconds() {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, 0, TimeSpan.Zero).AddMicroseconds(1);
            expected.AddNanoseconds(200)
                    .TruncateToMicroseconds()
                    .Should().Be(expected);
        }

        [Fact]
        public void Truncate_Given_Zero_Should_Return_Unchanged() {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            expected.Truncate(TimeSpan.Zero)
                    .Should().Be(expected);
        }

        [Fact]
        public void Truncate_Given_MinValue_Should_Return_Unchanged() {
            DateTimeOffset.MinValue
                          .Truncate(TimeSpan.FromMilliseconds(1))
                          .Should().Be(DateTimeOffset.MinValue);
        }

        [Fact]
        public void Truncate_Given_MaxValue_Should_Return_Unchanged() {
            DateTimeOffset.MaxValue
                          .Truncate(TimeSpan.FromMilliseconds(1))
                          .Should().Be(DateTimeOffset.MaxValue);
        }

        [Fact]
        public void IsTimeEquals_Ignore_Day() {
            var one     = new DateTimeOffset(2021, 02, 01, 1, 2, 3, TimeSpan.Zero);
            var another = new DateTimeOffset(2021, 02, 02, 1, 2, 3, TimeSpan.Zero);
            one.IsTimeEquals(another)
               .Should().BeTrue();
        }

        [Fact]
        public void IsTimeEquals_Ignore_Month() {
            var one     = new DateTimeOffset(2021, 02, 01, 1, 2, 3, TimeSpan.Zero);
            var another = new DateTimeOffset(2021, 03, 01, 1, 2, 3, TimeSpan.Zero);
            one.IsTimeEquals(another)
               .Should().BeTrue();
        }

        [Fact]
        public void IsTimeEquals_Ignore_Year() {
            var one     = new DateTimeOffset(2021, 02, 01, 1, 2, 3, TimeSpan.Zero);
            var another = new DateTimeOffset(2022, 02, 01, 1, 2, 3, TimeSpan.Zero);
            one.IsTimeEquals(another)
               .Should().BeTrue();
        }

        [Fact]
        public void IsTimeEquals_Check_Hour() {
            var one     = new DateTimeOffset(2021, 02, 01, 1, 2, 3, TimeSpan.Zero);
            var another = new DateTimeOffset(2021, 02, 01, 2, 2, 3, TimeSpan.Zero);
            one.IsTimeEquals(another)
               .Should().BeFalse();
        }

        [Fact]
        public void IsTimeEquals_Check_Minute() {
            var one     = new DateTimeOffset(2021, 02, 01, 1, 2, 3, TimeSpan.Zero);
            var another = new DateTimeOffset(2021, 02, 01, 1, 3, 3, TimeSpan.Zero);
            one.IsTimeEquals(another)
               .Should().BeFalse();
        }

        [Fact]
        public void IsTimeEquals_Check_Seconds() {
            var one     = new DateTimeOffset(2021, 02, 01, 1, 2, 3, TimeSpan.Zero);
            var another = new DateTimeOffset(2021, 02, 01, 1, 2, 4, TimeSpan.Zero);
            one.IsTimeEquals(another)
               .Should().BeFalse();
        }

        [Fact]
        public void IsTimeEquals_Check_Milliseconds() {
            var one     = new DateTimeOffset(2021, 02, 01, 1, 2, 3, 4, TimeSpan.Zero);
            var another = new DateTimeOffset(2021, 02, 01, 1, 2, 3, 5, TimeSpan.Zero);
            one.IsTimeEquals(another)
               .Should().BeFalse();
        }
        
        [Fact]
        public void IsTimeEquals_Check_With_Hour_Precision() {
            var one     = new DateTimeOffset(2021, 02, 01, 1, 3, 3, 4, TimeSpan.Zero);
            var another = new DateTimeOffset(2021, 02, 01, 1, 2, 3, 4, TimeSpan.Zero);
            one.IsTimeEquals(another, TimePrecision.Hour)
               .Should().BeTrue();
        }
        
        [Fact]
        public void IsTimeEquals_Check_With_Minute_Precision() {
            var one     = new DateTimeOffset(2021, 02, 01, 1, 2, 3, 4, TimeSpan.Zero);
            var another = new DateTimeOffset(2021, 02, 01, 1, 2, 2, 4, TimeSpan.Zero);
            one.IsTimeEquals(another, TimePrecision.Minute)
               .Should().BeTrue();
        }
        
        [Fact]
        public void IsTimeEquals_Check_With_Seconds_Precision() {
            var one     = new DateTimeOffset(2021, 02, 01, 1, 2, 3, 4, TimeSpan.Zero);
            var another = new DateTimeOffset(2021, 02, 01, 1, 2, 3, 5, TimeSpan.Zero);
            one.IsTimeEquals(another, TimePrecision.Minute)
               .Should().BeTrue();
        }
        
        [Fact]
        public void Nullable_IsTimeEquals_Given_Both_Nulls_Return_True() {
            DateTimeOffset? one= null;
            one.IsTimeEquals(null).Should().BeTrue();
        }
        
        [Fact]
        public void Nullable_IsTimeEquals_Given_One_Null_Return_False() {
            DateTimeOffset? one = null;
            one.IsTimeEquals(new DateTimeOffset(2021, 02, 01, 1, 2, 3, 4, TimeSpan.Zero))
               .Should().BeFalse();
        }
        
        [Fact]
        public void Nullable_IsTimeEquals_Given_Another_Null_Return_False() {
            DateTimeOffset? one = new DateTimeOffset(2021, 02, 01, 1, 2, 3, 4, TimeSpan.Zero);
            one.IsTimeEquals(null)
               .Should().BeFalse();
        }
    }
}