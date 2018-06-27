using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;
using static CSharpIsFun.Helpers.FPHelper;

namespace CSharpIsFunTests
{
    public class FunctionalProgrammingTests
    {
        [Fact]
        public void DoActionDoFuncTest()
        {
            const string expected = "Żytnia - 40% - 1l\r\nPiwo - 5% - 4l\r\nWino - 10% - 0l\r\nAbsynt - 74% - 2l\r\n";

            var orderLines = new List<Beverage>
            {
                new Beverage { Name = "Żytnia", AlcoholContent = 40, Amount = 1 },
                new Beverage { Name = "Piwo", AlcoholContent = 5, Amount = 4 },
                new Beverage { Name = "Wino", AlcoholContent = 10, Amount = 0 },
                new Beverage { Name = "Absynt", AlcoholContent = 74, Amount = 2 },
            };

            var sb = new StringBuilder();

            Func<Beverage, string> getDescription = beverage => $"{beverage.Name} - {beverage.AlcoholContent}% - {beverage.Amount}l";
            Action<string> appendBeverage= description => sb.AppendLine(description);

            orderLines.DoFunc(getDescription).DoAction(appendBeverage);

            var result = sb.ToString();

            result.Should().Be(expected);
        }

        private class Beverage
        {
            public string Name { get; set; }
            public float AlcoholContent { get; set; }
            public float Amount { get; set; }
        }
    }
}