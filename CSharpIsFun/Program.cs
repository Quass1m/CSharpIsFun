using System;
using CSharpIsFun.Helpers;
using CSharpIsFun.Features;
using CSharpIsFun.Runners;

namespace CSharpIsFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CSharpIsFun");

            //RunStringComparison.Run();

            SpanType.TestSpan();
            SpanType.TestReadOnlySpan();
            SpanType.TestSpanStackAlloc();



            Console.ReadKey();
        }
    }
}