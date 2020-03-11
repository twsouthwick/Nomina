namespace Nomina
{
    public class NamePattern
    {
        public NamePattern(NameCulture culture, string pattern)
        {
            Culture = culture;
            Pattern = pattern;
        }

        public NameCulture Culture{get;}

        public string Pattern { get; }
    }
}
