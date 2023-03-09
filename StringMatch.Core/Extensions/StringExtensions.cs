namespace StringMatch.Core.Extensions
{
    public static class StringExtensions
    {
        public static char[] ToLowerCaseCharArray(this string @this) =>
            @this?.ToCharArray()
                 .Select(c => char.ToLowerInvariant(c))
                 .ToArray() ?? Array.Empty<char>();
    }
}
