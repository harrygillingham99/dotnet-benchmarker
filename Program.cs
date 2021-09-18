using System;

namespace Benchmarker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new BenchmarkRunner.BenchmarkRunner().RunBenchmarks();

            Console.WriteLine("\n \n \n \nDone! Press any key to close...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}