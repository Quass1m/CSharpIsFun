using System;
using CSharpIsFun.Runners;

namespace CSharpIsFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CSharpIsFun");

            //RunStringComparison.Run();

            Features.SpanType.TestSpan();
            Features.SpanType.TestReadOnlySpan();
            Features.SpanType.TestSpanStackAlloc();



            Console.ReadKey();
        }
    }
}
