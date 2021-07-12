using System;
using FluentAssertions;
using Hrimsoft.Core.Extensions;
using Xunit;

namespace Hrimsoft.Core.Tests.Extensions
{
    public class DateTimeOffsetExtensionTests
    {
        [Fact]
        public void Truncate_Should_Cut_To_Milliseconds()
        {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, 20, TimeSpan.Zero);
            expected.AddMilliseconds(0.3)
                    .Truncate(TimeSpan.FromMilliseconds(1))
                    .Should().Be(expected);
        }

        [Fact]
        public void Truncate_Should_Cut_To_Seconds()
        {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            expected.AddMilliseconds(20)
                    .Truncate(TimeSpan.FromSeconds(10))
                    .Should().Be(expected);
        }

        [Fact]
        public void Truncate_Should_Cut_To_Minutes()
        {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            expected.AddSeconds(20.33)
                    .Truncate(TimeSpan.FromMinutes(1))
                    .Should().Be(expected);
        }

        [Fact]
        public void Truncate_Should_Cut_To_Hours()
        {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            expected.AddMinutes(20.33)
                    .Truncate(TimeSpan.FromHours(1))
                    .Should().Be(expected);
        }

        [Fact]
        public void TruncateToMilliseconds_Should_Cut_To_Milliseconds()
        {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, 20, TimeSpan.Zero);
            expected.AddMilliseconds(0.3)
                    .TruncateToMilliseconds()
                    .Should().Be(expected);
        }

        [Fact]
        public void TruncateToSeconds_Should_Cut_To_Seconds()
        {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            expected.AddMilliseconds(20)
                    .TruncateToSeconds()
                    .Should().Be(expected);
        }

        [Fact]
        public void Truncate_Given_Zero_Should_Return_Unchanged()
        {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.Zero);
            expected.Truncate(TimeSpan.Zero)
                    .Should().Be(expected);
        }

        [Fact]
        public void Truncate_Given_MinValue_Should_Return_Unchanged()
        {
            DateTimeOffset.MinValue
                    .Truncate(TimeSpan.FromMilliseconds(1))
                    .Should().Be(DateTimeOffset.MinValue);
        }
        
        [Fact]
        public void Truncate_Given_MaxValue_Should_Return_Unchanged()
        {
            DateTimeOffset.MaxValue
                    .Truncate(TimeSpan.FromMilliseconds(1))
                    .Should().Be(DateTimeOffset.MaxValue);
        }
    }
}