using System;
using System.Collections.Generic;
using System.Text;

namespace Nomina
{
    internal static class SplitExtensions
    {
        public static SpanSplitEnumerator<char> Split(this ReadOnlySpan<char> span)
            => new SpanSplitEnumerator<char>(span, ' ', StringSplitOptions.RemoveEmptyEntries);

        public static SpanSplitEnumerator<char> Split(this ReadOnlySpan<char> span, char separator)
            => new SpanSplitEnumerator<char>(span, separator, StringSplitOptions.RemoveEmptyEntries);
    }

    internal ref struct SpanSplitEnumerator<T> where T : IEquatable<T>
    {
        private readonly ReadOnlySpan<T> _sequence;
        private readonly StringSplitOptions _options;
        private readonly T _separator;
        private int _offset;
        private int _index;

        public SpanSplitEnumerator<T> GetEnumerator() => this;

        internal SpanSplitEnumerator(ReadOnlySpan<T> span, T separator, StringSplitOptions options)
        {
            _sequence = span;
            _separator = separator;
            _options = options;
            _index = 0;
            _offset = 0;
        }

        public Range Current => new Range(_offset, _offset + _index - 1);

        public bool MoveNext()
        {
            if (_sequence.Length - _offset < _index)
            {
                return false;
            }

            var slice = _sequence.Slice(_offset += _index);

            var nextIdx = slice.IndexOf(_separator);
            _index = (nextIdx != -1 ? nextIdx : slice.Length) + 1;

            if (_options == StringSplitOptions.RemoveEmptyEntries)
            {
                if (nextIdx == 0 || slice.Length == 0)
                {
                    return MoveNext();
                }
            }

            return true;
        }
    }
}
