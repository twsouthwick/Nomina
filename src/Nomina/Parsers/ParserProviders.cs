using System;
using System.Collections.Generic;
using System.Linq;

namespace Nomina.Parsers
{
    internal static class ParserProviders
    {
        public static IEnumerable<INameParser> GetParsers()
            => typeof(ParserProviders).Assembly
                .GetTypes()
                .Where(type => !type.IsInterface && !type.IsAbstract && typeof(INameParser).IsAssignableFrom(type))
                .Select(type => (INameParser)Activator.CreateInstance(type));
    }
}
