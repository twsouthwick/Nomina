using Nomina.Parsers;
using System;
using Xunit;

namespace Nomina.Tests
{
    public class AmericanEnglishNameParserTests
    {
        [Fact]
        public void EmptyName()
        {
            var parser = new AmericanEnglishNameParser();

            Assert.True(parser.TryGetFeature(string.Empty, NameFeature.FirstName, out var result));
            Assert.True(result.IsEmpty);
        }

        [InlineData("Hello")]
        [InlineData(" Hello")]
        [InlineData(" Hello ")]
        [Theory]
        public void OneName(string name)
        {
            var parser = new AmericanEnglishNameParser();

            Assert.True(parser.TryGetFeature(name, NameFeature.FirstName, out var result));
            Assert.Equal("Hello", result.ToString());
        }

        [InlineData("Hello World")]
        [InlineData(" Hello   World ")]
        [Theory]
        public void FirstAndLast(string name)
        {
            var parser = new AmericanEnglishNameParser();

            Assert.True(parser.TryGetFeature(name, NameFeature.FirstName, out var first));
            Assert.Equal("Hello", first.ToString());

            Assert.True(parser.TryGetFeature(name, NameFeature.LastName, out var last));
            Assert.Equal("World", last.ToString());
        }

    }
}
