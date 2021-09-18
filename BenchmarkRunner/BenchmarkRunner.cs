using System;
using System.Linq;
using System.Reflection;
using Benchmarker.Benchmarks.Templates;

namespace Benchmarker.BenchmarkRunner
{
    public class BenchmarkRunner
    {
        public void RunBenchmarks()
        {
            var benchmarks = typeof(Benchmark).Assembly.GetTypes().Where(x => typeof(Benchmark).IsAssignableFrom(x) && !x.IsAbstract);

            foreach (var benchmark in benchmarks)
            {
                var method = benchmark?.BaseType?.GetMethod("RunBenchmark", BindingFlags.Instance | BindingFlags.NonPublic);
                var instantiatedType = Activator.CreateInstance(benchmark);
                method?.Invoke(instantiatedType, null);
            }
        }
    }
}
