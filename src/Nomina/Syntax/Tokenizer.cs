using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Nomina.Syntax
{
    public static class Tokenizer
    {
        private enum TokenType
        {
            Whitespace,
            Text,
            EOF
        }

        public static IEnumerable<Token> Tokenize(ReadOnlySpan<char> pattern)
        {
            var list = new List<Token>();

            if (pattern.IsEmpty)
            {
                return Enumerable.Empty<Token>();
            }

            var current = GetType(pattern, 0);
            var idx = 1;

            while (!pattern.IsEmpty)
            {
                var type = GetType(pattern, idx);

                if (current != type)
                {
                    list.Add(CreateToken(current, pattern[..idx].ToString()));
                    current = type;
                    pattern = pattern[idx..];
                    idx = 0;
                }
                else
                {
                    current = type;
                    idx++;
                }
            }

            return list;
        }

        private static Token CreateToken(TokenType type, string value)
            => type switch
            {
                TokenType.Whitespace => new Whitespace(value),
                TokenType.Text => new Text(value),
                _ => throw new InvalidOperationException()
            };

        private static TokenType GetType(ReadOnlySpan<char> pattern, int idx)
        {
            if (idx >= pattern.Length)
            {
                return TokenType.EOF;
            }

            return pattern[idx] switch
            {
                ' ' => TokenType.Whitespace,
                _ => TokenType.Text
            };
        }
    }

    public abstract class Token
    {
    }

    public class Text : Token
    {
        public Text(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }

    public class Whitespace : Token
    {
        public Whitespace(string whitespace)
        {
            Value = whitespace;
        }

        public string Value { get; }
    }
}
