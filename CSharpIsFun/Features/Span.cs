using System;

namespace CSharpIsFun.Features
{
    public static class SpanType
    {
        public static void TestSpan()
        {
            Console.WriteLine(nameof(TestSpan));

            const int count = 10;
            int[] array = new int[count];

            // Create Span from unpopulated array
            Span<int> span = array.AsSpan();
            Span<int> slice = span.Slice(3, 5);

            for (int i = 0; i < count; i++)
                array[i] = i;

            Console.WriteLine("Print array:");
            foreach (int v in array)
                Console.WriteLine(v);

            // Span holds a reference to the array
            Console.WriteLine("Print span:");
            foreach (int v in span)
                Console.WriteLine(v);

            Console.WriteLine("Print slice of span:");
            foreach (int v in slice)
                Console.WriteLine(v);

            for (int i = 0; i < count; i++)
                span[i] += 10;

            Console.WriteLine("Print incremented span:");
            foreach (int v in span)
                Console.WriteLine(v);

            Console.WriteLine("Print array again:");
            foreach (int v in array)
                Console.WriteLine(v);

            ReadOnlySpan<int> readOnlySpan = array.AsSpan();

            Console.WriteLine("Print read only span:");
            foreach (int v in readOnlySpan)
                Console.WriteLine(v);

            for (int i = 0; i < count; i++)
            {
                //readOnlySpan[i] += 10; // won't compile
            }


        }

        public static void TestReadOnlySpan()
        {
            Console.WriteLine(nameof(TestReadOnlySpan));

            const int count = 10;
            int[] array = new int[count];
            
            for (int i = 0; i < count; i++)
                array[i] = i;

            Console.WriteLine("Print array:");
            foreach (int v in array)
                Console.WriteLine(v);

            ReadOnlySpan<int> readOnlySpan = array.AsSpan();

            Console.WriteLine("Print read only span:");
            foreach (int v in readOnlySpan)
                Console.WriteLine(v);

            for (int i = 0; i < count; i++)
            {
                //readOnlySpan[i] += 10; // won't compile
            }
        }

        public static void TestSpanStackAlloc()
        {
            Console.WriteLine(nameof(TestSpanStackAlloc));
            const int count = 10;

            Span<int> span = stackalloc int[count];
            ReadOnlySpan<int> readOnlySpan = span.Slice(3, 5);

            for (int i = 0; i < count; i++)
                span[i] = i;

            Console.WriteLine("Print span:");
            foreach (int v in span)
                Console.WriteLine(v);

            Console.WriteLine("Print read only span:");
            foreach (int v in readOnlySpan)
                Console.WriteLine(v);
        }
    }
}