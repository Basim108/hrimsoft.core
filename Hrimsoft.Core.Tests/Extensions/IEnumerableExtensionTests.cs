using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Hrimsoft.Core.Extensions;
using Xunit;

namespace Hrimsoft.Core.Tests.Extensions
{
    public class IEnumerableExtensionTests
    {
        [Fact]
        public void IsNullOrEmpty_Given_Null_Returns_True()
        {
            ((IEnumerable<int>) null).IsNullOrEmpty().Should().BeTrue();
        }
        
        [Fact]
        public void IsNullOrEmpty_Given_Empty_Returns_True()
        {
            Enumerable.Empty<int>().IsNullOrEmpty().Should().BeTrue();
        }
        
        [Fact]
        public void IsNullOrEmpty_Given_NotEmpty_Returns_False()
        {
            IEnumerable<int> list = new List<int>{1,2,3};
            list.IsNullOrEmpty().Should().BeFalse();
        }
        
        [Fact]
        public void IsNotEmpty_Given_NotEmpty_Returns_True()
        {
            IEnumerable<int> list = new List<int>{1,2,3};
            list.IsNotEmpty().Should().BeTrue();
        }
        
        [Fact]
        public void IsNotEmpty_Given_Empty_Returns_False()
        {
            Enumerable.Empty<int>().IsNotEmpty().Should().BeFalse();
        }
    }
}