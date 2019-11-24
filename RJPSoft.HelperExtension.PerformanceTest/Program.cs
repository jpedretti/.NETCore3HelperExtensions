using RJPSoft.HelperExtensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RJPSoft.HelperExtension.PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var stopWatch = new Stopwatch();
            #region ListTest

            var elements = 250_000_000;
            var dataList = new List<byte?>();
            var spaseArray = new double[] { 0, 0.25, 0.50, 0.75, 1 };

            foreach (var sparse in spaseArray)
            {
                Console.Write($"{sparse*100}% sparse list: ");
                Generate(elements, 0);
                var result = Measure();
                Console.Write(result);
                Console.WriteLine();
            }

            #endregion

            static string Format(TimeSpan ellapsed)
            {
                return string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ellapsed.Hours, ellapsed.Minutes, ellapsed.Seconds,
                ellapsed.Milliseconds / 10);
            }

            void Generate(int numOfElements, double sparse)
            {
                dataList.Clear();
                for (var i = 0; i < numOfElements; i++)
                {
                    var n = rnd.NextDouble();
                    dataList.Add(n >= sparse ? 1 : (byte?)null);
                }
            }

            string Measure()
            {
                stopWatch.Restart();
                var _ = dataList.FilterNotNull();
                stopWatch.Stop();
                return Format(stopWatch.Elapsed);
            }
        }
    }
}
