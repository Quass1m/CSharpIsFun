using System;
using System.Diagnostics;

namespace CSharpIsFun.Helpers
{
    public static class StopwatchHelper
    {
        /// <summary>
        /// By JobSkeet: https://stackoverflow.com/a/969327/3917133
        /// </summary>
        public static TimeSpan Time(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}