using FluentAssertions;
using Hrimsoft.Core.Helpers;
using Xunit;

namespace Hrimsoft.Core.Tests.Helpers
{
    public class EnumParseAnywayTests
    {
        enum TestEnum { Value1, Value2 }
        
        [Fact]
        public void Should_Set_Default_Value()
        {
            EnumHelpers.ParseAnyway(null, TestEnum.Value2).Should().Be(TestEnum.Value2);
        }
        
        [Fact]
        public void Should_Set_Parsed_Value()
        {
            EnumHelpers.ParseAnyway("Value1", TestEnum.Value2).Should().Be(TestEnum.Value1);
        }
    }
}