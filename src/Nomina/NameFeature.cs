using System;

namespace Nomina
{
    public readonly partial struct NameFeature : IEquatable<NameFeature>
    {
        private readonly string _feature;

        public NameFeature(string feature)
        {
            _feature = feature;
        }

        public override bool Equals(object obj)
            => obj is NameFeature other ? Equals(other) : false;

        public bool Equals(NameFeature other)
            => string.Equals(_feature, other._feature, StringComparison.OrdinalIgnoreCase);

        public override int GetHashCode()
        {
            var hash = new HashCode();

            hash.Add(_feature, StringComparer.OrdinalIgnoreCase);

            return hash.ToHashCode();
        }

        public static implicit operator NameFeature(string feature) => new NameFeature(feature);
    }
}
