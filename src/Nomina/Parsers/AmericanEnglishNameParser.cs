using System;
using System.Collections.Generic;

namespace Nomina.Parsers
{
    public class AmericanEnglishNameParser : INameParser
    {
        public NameCulture Culture => "en-US";

        public IReadOnlyCollection<NameFeature> SupportedFeatures { get; } = new[]
        {
            NameFeature.FirstName,
            NameFeature.AlternateNames,
            NameFeature.LastName,
        };

        public bool TryGetFeature(ReadOnlySpan<char> input, NameFeature feature, out ReadOnlySpan<char> result)
        {
            if (input.IsEmpty)
            {
                result = string.Empty;
                return true;
            }

            result = default;
            return false;
        }
    }
}
