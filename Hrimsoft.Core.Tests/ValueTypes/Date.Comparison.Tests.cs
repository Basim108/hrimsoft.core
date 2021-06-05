using System;
using FluentAssertions;
using Hrimsoft.Core.Extensions;
using Hrimsoft.Core.ValueTypes;
using Xunit;

namespace Hrimsoft.Core.Tests.ValueTypes
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
    }
}