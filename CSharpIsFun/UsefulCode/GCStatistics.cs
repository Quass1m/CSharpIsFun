using System;
using System.Diagnostics;

namespace CSharpIsFun.UsefulCode
{
    public static class GCStatistics
    {
        /// <summary>
        /// GC Simple statistics read example
        /// </summary>
        /// <see cref="https://medium.com/@indy_singh/strings-are-evil-a803d05e5ce3"/>
        public static void Stats()
        {
            AppDomain.MonitoringIsEnabled = true;

            // do the parsing

            Console.WriteLine($"Took: {AppDomain.CurrentDomain.MonitoringTotalProcessorTime.TotalMilliseconds:#,###} ms");
            Console.WriteLine($"Allocated: {AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize / 1024:#,#} kb");
            Console.WriteLine($"Peak Working Set: {Process.GetCurrentProcess().PeakWorkingSet64 / 1024:#,#} kb");

            for (int index = 0; index <= GC.MaxGeneration; index++)
            {
                Console.WriteLine($"Gen {index} collections: {GC.CollectionCount(index)}");
            }
        }
    }
}
