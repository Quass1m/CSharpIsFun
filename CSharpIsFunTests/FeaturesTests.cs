using FluentAssertions;
using System;
using Xunit;
using CSharpIsFun.Features;

namespace CSharpIsFunTests
{
    public class FeaturesTests
    {
        [Fact]
        public void OutVariablesTest1()
        {
            OutVariables.GetOutVariableFromTryParse("5").Should().Be(5);
        }

        [Fact]
        public void OutVariablesTest2()
        {
            Action res1 = (() => OutVariables.GetOutVariableFromTryParse("nope"));
            res1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Tuples1Test1()
        {
            // C# 7.1 ?
            var tuple = Tuples.Tuples1("str1", 1);
            tuple.s.Should().Be("str1");
            tuple.i.Should().Be(1);
        }

        [Fact]
        public void Tuples1Test2()
        {
            var tuple = Tuples.Tuples1("str2", 2);
            var (first, second) = tuple.ToTuple();
            first.Should().Be("str2");
            second.Should().Be(2);
        }

        [Fact]
        public void Tuples2Test1()
        {
            var tuple = Tuples.Tuples2("str3", 3);
            tuple.first.Should().Be("str3");
            tuple.second.Should().Be(3);
        }

        [Fact]
        public void Tuples2Test2()
        {
            var (First, Second) = Tuples.Tuples2("str4", 4);
            First.Should().Be("str4");
            Second.Should().Be(4);
        }

        [Fact]
        public void DiscardsTest()
        {
            int max = Discards.DiscardFromMaxMinRange(new[] { 5, 3, 3, 8, 1, 45, 22 });
            max.Should().Be(45);
        }

        [Fact]
        public void RefLocalsAndReturnsTest()
        {
            int[,] matrix = { { 1, 4, 6 }, { 3, 5, 9 } };
            ref int result = ref RefLocals.Find(matrix, i => i >= 5);
            result.Should().Be(6);
            result = 10;
            matrix[0, 2].Should().Be(10);

        }

        // ToDo: improve this test
        [Fact]
        public void TestReferenceSemantics()
        {
            int a = 1;
            int b = 10;
            int c = a.OrMaybe(ref b);
            int d = a.OrMaybeIn(in b);
            int e = a.OrMaybeIn(20);
            ref int f = ref a.OrMaybeRef(100);

            //WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}, e = {e}, f = {f}");

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
                //WriteLine($"a = {*pa}, b = {*pb}, c = {*pc}, d = {*pd}, e = {*pe}, f = {f}");
            }

            //WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}, e = {e}, f = {f}");

            int g = a.OrMaybeInWorking(in b);
            //WriteLine($"g = {g}, b = {b}");
        }
    }
}
