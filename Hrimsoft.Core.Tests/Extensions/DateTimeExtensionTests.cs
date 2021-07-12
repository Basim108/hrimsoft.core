using System;
using FluentAssertions;
using Hrimsoft.Core.Extensions;
using Xunit;

namespace Hrimsoft.Core.Tests.Extensions
{
    public class DateTimeExtensionTests
    {
        [Fact]
        public void Truncate_Should_Cut_To_Milliseconds()
        {
            var expected = new DateTime(2021, 02, 01, 0, 0, 0);
            expected.AddMilliseconds(20.3)
                    .Truncate(TimeSpan.FromMilliseconds(1))
                    .Should().Be(new DateTime(2021, 02, 01, 0, 0, 0).AddMilliseconds(20));
        }

        [Fact]
        public void Truncate_Should_Cut_To_Seconds()
        {
            var expected = new DateTime(2021, 02, 01, 0, 0, 0);
            expected.AddMilliseconds(20)
                    .Truncate(TimeSpan.FromSeconds(10))
                    .Should().Be(new DateTime(2021, 02, 01, 0, 0, 0));
        }

        [Fact]
        public void Truncate_Should_Cut_To_Minutes()
        {
            var expected = new DateTime(2021, 02, 01, 0, 0, 0);
            expected.AddSeconds(20.33)
                    .Truncate(TimeSpan.FromMinutes(1))
                    .Should().Be(new DateTime(2021, 02, 01, 0, 0, 0));
        }

        [Fact]
        public void Truncate_Should_Cut_To_Hours()
        {
            var expected = new DateTime(2021, 02, 01, 0, 0, 0);
            expected.AddMinutes(20.33)
                    .Truncate(TimeSpan.FromHours(1))
                    .Should().Be(new DateTime(2021, 02, 01, 0, 0, 0));
        }

        [Fact]
        public void TruncateToMilliseconds_Should_Cut_To_Milliseconds()
        {
            var expected = new DateTime(2021, 02, 01, 0, 0, 0);
            expected.AddMilliseconds(20.3)
                    .TruncateToMilliseconds()
                    .Should().Be(new DateTime(2021, 02, 01, 0, 0, 0).AddMilliseconds(20));
        }

        [Fact]
        public void TruncateToSeconds_Should_Cut_To_Seconds()
        {
            var expected = new DateTime(2021, 02, 01, 0, 0, 0);
            expected.AddMilliseconds(20)
                    .TruncateToSeconds()
                    .Should().Be(new DateTime(2021, 02, 01, 0, 0, 0));
        }

        [Fact]
        public void Truncate_Given_Zero_Should_Return_Unchanged()
        {
            var expected = new DateTime(2021, 02, 01, 0, 0, 0);
            expected.Truncate(TimeSpan.Zero)
                    .Should().Be(new DateTime(2021, 02, 01, 0, 0, 0));
        }

        [Fact]
        public void Truncate_Given_MinValue_Should_Return_Unchanged()
        {
            DateTime.MinValue
                    .Truncate(TimeSpan.FromMilliseconds(1))
                    .Should().Be(DateTime.MinValue);
        }
        
        [Fact]
        public void Truncate_Given_MaxValue_Should_Return_Unchanged()
        {
            DateTime.MaxValue
                    .Truncate(TimeSpan.FromMilliseconds(1))
                    .Should().Be(DateTime.MaxValue);
        }
    }
}