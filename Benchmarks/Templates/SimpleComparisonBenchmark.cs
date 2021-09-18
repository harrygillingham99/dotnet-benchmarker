using System;
using System.Collections.Generic;

namespace Benchmarker.Benchmarks.Templates
{
    public abstract class SimpleComparisonBenchmark : Benchmark
    {
        private readonly List<(string variantName, Action benchmarkDelegate)> _benchmarkDelegates;

        protected SimpleComparisonBenchmark(string name, string description,
            List<(string variantName, Action benchmarkDelegate)> benchmarkDelegates) : base(name, description)
        {
            _benchmarkDelegates = benchmarkDelegates;
        }

        /*
         * This method will be called by reflection at runtime
         */
        protected void RunBenchmark()
        {
            PrintBenchmarkDetails();

            foreach (var (variantName, runDelegate) in _benchmarkDelegates)
            {
                Console.WriteLine(variantName);

                StartStopwatch();

                runDelegate.Invoke();

                Console.WriteLine(
                    $"{variantName} took {ResetStopwatchAndReturnElapsed().TotalMilliseconds}mss to complete.");
            }
        }
    }
}