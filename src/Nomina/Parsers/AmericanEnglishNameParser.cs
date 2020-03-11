using System;
using System.Collections.Generic;

namespace Nomina.Parsers
{
    public class AmericanEnglishNameParser : INameParser
    {
        private delegate ReadOnlySpan<char> MapFunc(ReadOnlySpan<char> input);

        private readonly Dictionary<NameFeature, MapFunc> _map;

        public NameCulture Culture => "en-US";

        public AmericanEnglishNameParser()
        {
            _map = new Dictionary<NameFeature, MapFunc>
            {
                { NameFeature.FirstName, GetFirstName },
                { NameFeature.LastName, GetLastName },
            };
        }

        public IReadOnlyCollection<NameFeature> SupportedFeatures => _map.Keys;

        public bool TryGetFeature(ReadOnlySpan<char> input, NameFeature feature, out ReadOnlySpan<char> result)
        {
            if (input.IsEmpty)
            {
                result = string.Empty;
                return true;
            }

            if (_map.TryGetValue(feature, out var func))
            {
                result = func(input);
                return !result.IsEmpty;
            }

            result = string.Empty;
            return false;
        }

        private ReadOnlySpan<char> GetFirstName(ReadOnlySpan<char> input)
        {
            var e = input.Split();

            if (e.MoveNext())
            {
                return input[e.Current];
            }

            return string.Empty;
        }

        private ReadOnlySpan<char> GetLastName(ReadOnlySpan<char> input)
        {
            var e = input.Split();
            Range r = default;

            while (e.MoveNext())
            {
                r = e.Current;
            }

            return input[r];
        }
    }
}

