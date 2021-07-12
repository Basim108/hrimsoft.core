using System.Runtime.InteropServices;
using FluentAssertions;
using Hrimsoft.Core.ValueObjects;
using Xunit;

namespace Hrimsoft.Core.Tests.ValueObjects
{
    public class DateTests
    {
        [Fact]
        public void Date_Is_No_Bigger_Than_4_Bytes()
        {
            int size = Marshal.SizeOf(typeof(Date));
            (size <= 4).Should().Be(true);
        }

        [Fact]
        public void AddDays_Should_Add_Negative_Values()
        {
            new Date(2021, 2, 2).AddDays(-1)
                                .Should()
                                .Be(new Date(2021, 2, 1));
        }

        [Fact]
        public void AddDays_Should_Add_Fractional_Values()
        {
            new Date(2021, 2, 2).AddDays(0.5)
                                .Should()
                                .Be(new Date(2021, 2, 2));
            new Date(2021, 2, 2).AddDays(1.5)
                                .Should()
                                .Be(new Date(2021, 2, 3));
        }

        [Fact]
        public void AddDays_Should_Add_Cross_Month_Value()
        {
            new Date(2021, 1, 31).AddDays(1)
                                 .Should()
                                 .Be(new Date(2021, 2, 1));
        }
    }
}