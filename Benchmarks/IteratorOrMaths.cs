using Benchmarker.Benchmarks.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarker.Benchmarks
{
    public class IteratorOrMaths : SimpleComparisonBenchmark
    {
        private static double LoopAmount
        {
            get
            {
                return 10 * Math.Pow(10, 5);
            }
        }

        public IteratorOrMaths() : base("Iterator or summation", "Comparing iterating through a list and summing or a mathematical algorithm", 
            new List<(string variantName, Action benchmarkDelegate)>
        {
            ("Iterator", () =>
            {
                var sum = 0;

            for (var i = 1; i <= LoopAmount; i++)
            {
                sum += i;
            }
            }),
            ("Summation", () => 
            {
                var n = LoopAmount; // upper bound
                var sumTwo = (n * (n + 1)) / 2;
            })
        })
        {

        }
    }
}
