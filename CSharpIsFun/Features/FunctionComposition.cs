using System;
using System.Net.Http;
using Newtonsoft.Json;
using static CSharpIsFun.Helpers.FPHelper;

namespace CSharpIsFun.Features
{
    /// <summary>
    /// Example of C# Functional Programming
    /// Function Composition
    /// </summary>
    /// <see cref="https://devstyle.pl/2018/06/14/funkcyjna-kompozycja-w-c-sharp/"/>
    public class FunctionComposition
    {
        public static void ExampleIExtradingComposition()
        {
            Func<string, string> normalizeSymbol = symbol => symbol.ToLower();

            var fetchChart = Curry<string, string, string>((period, symbol) =>
            {
                using (var httpClient = new HttpClient())
                {
                    return httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/chart/{period}").Result;
                }
            });

            Func<string, ChartItem> getChartItems = Compose(
                normalizeSymbol,
                fetchChart("1m"),
                JsonConvert.DeserializeObject<ChartItem[]>,
                Reduce<ChartItem>((candidate, item) => candidate.Close > item.Close ? candidate : item)
            );

            var max = getChartItems("AAPL");
            Console.WriteLine(max.Close);
        }

        private class ChartItem
        {
            public DateTime Date { get; set; }
            public double Close { get; set; }
        }
    }
}