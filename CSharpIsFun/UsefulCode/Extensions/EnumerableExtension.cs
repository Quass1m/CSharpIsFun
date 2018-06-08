using System.Collections.Generic;

namespace CSharpIsFun.UsefulCode.Extensions
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }
    }
}