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
    }
}
