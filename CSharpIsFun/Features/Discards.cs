using System.Collections.Generic;

namespace CSharpIsFun.Features
{
    public static class Discards
    {
        public static int DiscardFromMaxMinRange(IEnumerable<int> numbers)
        {
            // Return only max value
            var (max, _) = Range(numbers);

            return max;
        }

        private static (int Max, int Min) Range(IEnumerable<int> numbers)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (var n in numbers)
            {
                min = (n < min) ? n : min;
                max = (n > max) ? n : max;
            }

            return (max, min);
        }
    }
}