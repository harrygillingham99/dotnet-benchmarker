using System;
using System.Collections.Generic;
using Benchmarker.Benchmarks.Templates;

namespace Benchmarker.Benchmarks
{
    public class IteratorOrMaths : SimpleComparisonBenchmark
    {
        public IteratorOrMaths() : base("Iterator or summation",
            "Comparing iterating through a list and summing or a mathematical algorithm",
            new List<(string variantName, Action benchmarkDelegate)>
            {
                ("Iterator", () =>
                {
                    var sum = 0;

                    for (var i = 1; i <= LoopAmount; i++) sum += i;
                }),
                ("Summation", () =>
                {
                    var n = LoopAmount; // upper bound
                    var sumTwo = n * (n + 1) / 2;
                })
            })
        {
        }

        private static double LoopAmount => 10 * Math.Pow(10, 5);
    }
}