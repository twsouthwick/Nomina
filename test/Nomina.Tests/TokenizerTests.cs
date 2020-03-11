using Nomina.Syntax;
using Xunit;

namespace Nomina.Tests
{
    public class TokenizerTests
    {
        [Fact]
        public void EmptyList()
        {
            var result = Tokenizer.Tokenize(string.Empty);

            Assert.Empty(result);
        }

        [Fact]
        public void Whitespace()
        {
            const string Text = "   ";
            var result = Tokenizer.Tokenize(Text);

            var r = Assert.Single(result);
            var w = Assert.IsType<Whitespace>(r);
            Assert.Equal(Text, w.Value);
        }
    }
}
