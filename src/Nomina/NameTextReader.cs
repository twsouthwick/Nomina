using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nomina
{
    public class NameTextReader : IEnumerable<NamePattern>
    {
        private readonly TextReader _reader;

        public NameTextReader(TextReader reader)
        {
            _reader = reader;
        }

        public IEnumerator<NamePattern> GetEnumerator()
        {
            while (true)
            {
                var line = _reader.ReadLine();

                if (line is null)
                {
                    yield break;
                }

                if (!line.StartsWith("#", StringComparison.Ordinal))
                {
                    var span = line.AsSpan().Trim();
                    var idx = span.IndexOf(' ');

                    if (idx > 0)
                    {
                        var culture = span.Slice(0, idx);
                        var pattern = span.Slice(idx).Trim();

                        yield return new NamePattern(culture.ToString(), pattern.ToString());
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
