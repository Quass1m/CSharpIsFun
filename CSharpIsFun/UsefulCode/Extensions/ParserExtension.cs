using System;

namespace CSharpIsFun.UsefulCode.Extensions
{
    public static class ParserExtension
    {
        public static int ParseDefaultInt(this string @string, int @default)
        {
            return int.TryParse(@string, out var result) ? result : @default;
        }

        public static TimeSpan ParseDefaultTimeSpan(this string timeSpan, TimeSpan @default)
        {
            return TimeSpan.TryParse(timeSpan, out var result) ? result : @default;
        }
    }
}
