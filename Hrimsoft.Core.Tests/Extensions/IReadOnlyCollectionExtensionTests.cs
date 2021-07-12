using System.Collections.Generic;
using FluentAssertions;
using Hrimsoft.Core.Extensions;
using Xunit;

namespace Hrimsoft.Core.Tests.Extensions
{
    public class IReadOnlyCollectionExtensionTests
    {
        [Fact]
        public void IsNullOrEmpty_Given_Null_Returns_True()
        {
            ((IReadOnlyCollection<int>) null).IsNullOrEmpty().Should().BeTrue();
        }
        
        [Fact]
        public void IsNullOrEmpty_Given_Empty_Returns_True()
        {
            ((IReadOnlyCollection<int>)new List<int>()).IsNullOrEmpty().Should().BeTrue();
        }
        
        [Fact]
        public void IsNullOrEmpty_Given_NotEmpty_Returns_False()
        {
            IReadOnlyCollection<int> list = new List<int>{1,2,3};
            list.IsNullOrEmpty().Should().BeFalse();
        }
        
        [Fact]
        public void IsNotEmpty_Given_NotEmpty_Returns_True()
        {
            IReadOnlyCollection<int> list = new List<int>{1,2,3};
            list.IsNotEmpty().Should().BeTrue();
        }
        
        [Fact]
        public void IsNotEmpty_Given_Empty_Returns_False()
        {
            ((IReadOnlyCollection<int>)new List<int>()).IsNotEmpty().Should().BeFalse();
        }
    }
}