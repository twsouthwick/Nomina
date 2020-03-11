using System;

namespace Nomina
{
    public readonly struct NameCulture : IEquatable<NameCulture>
    {
        public NameCulture(string culture)
        {
            Culture = culture;
        }

        public string Culture { get; }

        public override bool Equals(object obj)
            => obj is NameCulture other ? Equals(other) : false;

        public bool Equals(NameCulture other)
            => string.Equals(Culture, other.Culture, StringComparison.OrdinalIgnoreCase);

        public override int GetHashCode()
        {
            var hash = new HashCode();

            hash.Add(Culture, StringComparer.OrdinalIgnoreCase);

            return hash.ToHashCode();
        }

        public override string ToString() => Culture;

        public static implicit operator NameCulture(string culture) => new NameCulture(culture);
    }
}
