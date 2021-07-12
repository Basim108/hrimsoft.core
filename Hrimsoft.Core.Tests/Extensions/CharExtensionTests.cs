using FluentAssertions;
using Hrimsoft.Core.Extensions;
using Xunit;

namespace Hrimsoft.Core.Tests.Extensions
{
    public class CharExtensionTests
    {
        [Fact]
        public void IsAnEnglishLetter_Given_LowerCase_Letter_Returns_True()
        {
            for (byte i = 97; i < 123; i++) {
                ((char) i).IsAnEnglishLetter().Should().BeTrue();
            }
        }

        [Fact]
        public void IsAnEnglishLetter_Given_UpperCase_Letter_Returns_True()
        {
            for (byte i = 65; i < 91; i++) {
                ((char) i).IsAnEnglishLetter().Should().BeTrue();
            }
        }
        
        [Fact]
        public void IsUpperCase_Given_UpperCase_Returns_True()
        {
            for (byte i = 65; i < 91; i++) {
                ((char) i).IsUpperCase().Should().BeTrue();
            }
        }
        
        [Fact]
        public void IsUpperCase_Given_LowerCase_Returns_False()
        {
            for (byte i = 97; i < 123; i++) {
                ((char) i).IsUpperCase().Should().BeFalse();
            }
        }
        
        [Fact]
        public void IsLowerCase_Given_UpperCase_Returns_False()
        {
            for (byte i = 65; i < 91; i++) {
                ((char) i).IsLowerCase().Should().BeFalse();
            }
        }
        
        [Fact]
        public void IsLowerCase_Given_LowerCase_Returns_True()
        {
            for (byte i = 97; i < 123; i++) {
                ((char) i).IsLowerCase().Should().BeTrue();
            }
        }
        
        [Fact]
        public void IsAnEnglishLetter_Given_Non_Letter_Returns_False()
        {
            for (byte i = 0; i < 65; i++) {
                ((char) i).IsAnEnglishLetter().Should().BeFalse();
            }
            for (byte i = 91; i < 97; i++) {
                ((char) i).IsAnEnglishLetter().Should().BeFalse();
            }
            for (byte i = 123; i < 255; i++) {
                ((char) i).IsAnEnglishLetter().Should().BeFalse();
            }
        }
        
        [Fact]
        public void IsDelimiter_Given_Space_Returns_True()
        {
            ' '.IsDelimiter().Should().BeTrue();
        }
        
        [Fact]
        public void IsDelimiter_Given_Underscore_Returns_True()
        {
            '_'.IsDelimiter().Should().BeTrue();
        }
        
        [Fact]
        public void IsDelimiter_Given_Dot_Returns_True()
        {
            '.'.IsDelimiter().Should().BeTrue();
        }
    }
}