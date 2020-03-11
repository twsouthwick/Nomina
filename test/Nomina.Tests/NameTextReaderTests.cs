using System.IO;
using Xunit;

namespace Nomina.Tests
{
    public class NameTextReaderTests
    {
        [Fact]
        public void Empty()
        {
            using var reader = new StringReader(string.Empty);
            var nameReader = new NameTextReader(reader);

            Assert.Empty(nameReader);
        }

        [Fact]
        public void Comments()
        {
            using var reader = new StringReader("# comment 1\n# comment 2");
            var nameReader = new NameTextReader(reader);

            Assert.Empty(nameReader);
        }

        [Fact]
        public void Whitespace()
        {
            using var reader = new StringReader("\n\n\n\n");
            var nameReader = new NameTextReader(reader);

            Assert.Empty(nameReader);
        }

        [Fact]
        public void SingleLine()
        {
            const string text = @"
en-US Some pattern
";
            using var reader = new StringReader(text);
            var nameReader = new NameTextReader(reader);

            var pattern = Assert.Single(nameReader);

            Assert.Equal("en-US", pattern.Culture);
            Assert.Equal("Some pattern", pattern.Pattern);
        }
    }
}
