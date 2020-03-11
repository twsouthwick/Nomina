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
    }
}
