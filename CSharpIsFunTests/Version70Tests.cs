using FluentAssertions;
using System;
using Xunit;
using LangFeatures70.LangFeatures;

namespace CSharpIsFunTests
{
    public class Version70Tests
    {
        [Fact]
        public void OutVariablesTest1()
        {
            Version70.OutVariables("5").Should().Be(5);
        }

        [Fact]
        public void OutVariablesTest2()
        {
            Action res1 = (() => Version70.OutVariables("nope"));
            res1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Tuples1Test1()
        {
            // C# 7.1 ?
            var tuple = Version70.Tuples1("str1", 1);
            tuple.s.Should().Be("str1");
            tuple.i.Should().Be(1);
        }

        [Fact]
        public void Tuples1Test2()
        {
            var tuple = Version70.Tuples1("str2", 2);
            var (first, second) = tuple.ToTuple();
            first.Should().Be("str2");
            second.Should().Be(2);
        }

        [Fact]
        public void Tuples2Test1()
        {
            var tuple = Version70.Tuples2("str3", 3);
            tuple.First.Should().Be("str3");
            tuple.Second.Should().Be(3);
        }

        [Fact]
        public void Tuples2Test2()
        {
            var (First, Second) = Version70.Tuples2("str4", 4);
            First.Should().Be("str4");
            Second.Should().Be(4);
        }

        [Fact]
        public void DiscardsTest()
        {
            int max = Version70.Discards(new[] { 5, 3, 3, 8, 1, 45, 22 });
            max.Should().Be(45);
        }

        [Fact]
        public void RefLocalsAndReturnsTest()
        {
            int[,] matrix = { { 1, 4, 6 }, { 3, 5, 9 } };
            ref int result = ref Version70.Find(matrix, i => i >= 5);
            result.Should().Be(6);
            result = 10;
            matrix[0, 2].Should().Be(10);

        }

        [Fact]
        public void Test()
        {
        }
    }
}
