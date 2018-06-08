using System;
using CSharpIsFun.Helpers;
using CSharpIsFun.Features;
using CSharpIsFun.Runners;
using System.IO;

namespace CSharpIsFun
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CSharpIsFun");

            //RunStringComparison.Run();

            //SpanType.TestSpan();
            //SpanType.TestReadOnlySpan();
            //SpanType.TestSpanStackAlloc();
            Console.WriteLine(SpanType.TestMemoryType());

            Console.ReadKey();
        }
    }
}