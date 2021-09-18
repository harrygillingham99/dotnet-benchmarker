using System;
using System.Linq;
using System.Reflection;
using Benchmarker.Benchmarks.Templates;

namespace Benchmarker
{
    class Program
    {
        static void Main(string[] args)
        {
            var benchmarks = typeof(Benchmark).Assembly.GetTypes().Where(x => typeof(Benchmark).IsAssignableFrom(x) && !x.IsAbstract);

            foreach (var benchmark in benchmarks)
            {
                var method = benchmark?.BaseType?.GetMethod("RunBenchmark", BindingFlags.Instance | BindingFlags.NonPublic);
                var instantiatedType = Activator.CreateInstance(benchmark);
                method?.Invoke(instantiatedType, null);
            }

            Console.WriteLine("\n \n \n \nDone! Press any key to close...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
