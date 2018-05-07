using AutoFixture;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using static CSharpIsFun.Helpers.StopwatchHelper;

namespace CSharpIsFun.Runners
{
    public class RunStringComparison
    {
        public static void Run()
        {
            const int count = 1000000;
            var fixture = new Fixture();
            var strings = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var generatedTextWithPrefix = fixture.Create("str");
                strings.Add(generatedTextWithPrefix);
            }

            var list1 = strings.RandomSubset(count / 2).ToList();
            var list2 = strings.RandomSubset(count / 2).ToList();

            var comparer = new StringComparison(list1, list2);

            Console.WriteLine(Time(() => comparer.CompareLowercase()));
            Console.WriteLine(Time(() => comparer.CompareUppercase()));
            Console.WriteLine(Time(() => comparer.CompareStringEquals()));
        }
    }
}