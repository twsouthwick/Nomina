using System;
using System.Collections.Generic;

namespace Nomina
{
    public interface INameParser
    {
        public NameCulture Culture { get; }

        public bool TryGetFeature(ReadOnlySpan<char> input, NameFeature feature, out ReadOnlySpan<char> result);

        public IReadOnlyCollection<NameFeature> SupportedFeatures { get; }
    }
}
