using System;
using static System.Console;

namespace LangFeatures73
{
    static class Program
    {
        // Reference type extension method
        static int OrMaybe(this ref int x, ref int y)
        {
            x++;
            y--;

            return x;
        }

        static int OrMaybeIn(this ref int x, in int y)
        {
            x++;
            //y--; // not permitted due to 'in' keyword

            return x;
        }

        static ref int OrMaybeRef(this ref int x, in int y)
        {
            x++;

            return ref x;
        }

        static void Main(string[] args)
        {
            int a = 1;
            int b = 10;
            int c = a.OrMaybe(ref b);
            int d = a.OrMaybeIn(in b);
            int e = a.OrMaybeIn(20);
            ref int f = ref a.OrMaybeRef(100);

            WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}, e = {e}, f = {f}");

            unsafe
            {
                int* pa = &a;
                *pa = 0xfaaa;
                int* pb = &b;
                *pb = 0xfbbb;
                int* pc = &c;
                *pc = 0xfccc;
                int* pd = &d;
                *pd = 0xfddd;
                int* pe = &e;
                *pe = 0xfeee;
                WriteLine($"a = {*pa}, b = {*pb}, c = {*pc}, d = {*pd}, e = {*pe}, f = {f}");
            }

            WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}, e = {e}, f = {f}");
            
            ReadKey();
        }
    }
}
