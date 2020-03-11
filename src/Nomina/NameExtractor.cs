using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nomina
{
    public class NameExtractor
    {
        private readonly Dictionary<NameCulture, INameParser> _parsers;

        public NameExtractor()
            : this(Parsers.ParserProviders.GetParsers())
        {
        }

        public NameExtractor(IEnumerable<INameParser> parsers)
        {
            _parsers = parsers.ToDictionary(p => p.Culture);
        }

        public bool TryGetParser(NameCulture culture, out INameParser parser)
        {
            return _parsers.TryGetValue(culture, out parser);
        }
    }
}
