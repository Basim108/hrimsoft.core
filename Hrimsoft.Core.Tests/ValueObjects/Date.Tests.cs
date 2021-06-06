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
    }
}