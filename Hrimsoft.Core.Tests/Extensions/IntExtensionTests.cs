using System;
using FluentAssertions;
using Hrimsoft.Core.Extensions;
using Xunit;

namespace Hrimsoft.Core.Tests.Extensions
{
    public class IntExtensionTests
    {
        [Fact]
        public void ToDateTimeOffset_Given_UTC_Returns_Correct()
        {
            var expected = new DateTimeOffset(2021, 02, 01, 0,0,0, TimeSpan.Zero);
            var epoche = (int)expected.ToUnixTimeSeconds();
            epoche.ToDateTimeOffset(0).Should().Be(expected);
        }
        
        [Fact]
        public void ToDateTimeOffset_Given_With_Offset_Returns_Correct()
        {
            var expected = new DateTimeOffset(2021, 02, 01, 0, 0, 0, TimeSpan.FromHours(3));
            var epoche   = (int)expected.ToUnixTimeSeconds();
            epoche.ToDateTimeOffset(3 * 60 * 60).Should().Be(expected);
        }
    }
}