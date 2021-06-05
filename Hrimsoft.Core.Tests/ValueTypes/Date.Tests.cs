using System;
using FluentAssertions;
using Hrimsoft.Core.Extensions;
using Hrimsoft.Core.ValueTypes;
using Xunit;

namespace Hrimsoft.Core.Tests.ValueTypes
{
    public class DateTests
    {
        [Fact]
        public void Date_Is_No_Bigger_Than_4_Bytes()
        {
            int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Date));
            (size <= 4).Should().Be(true);
        }
    }
}