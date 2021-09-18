using System;
using System.Diagnostics;

namespace Benchmarker.Benchmarks.Templates
{
    public abstract class Benchmark
    {
        private readonly string _description;
        private readonly string _name;
        private readonly Stopwatch _stopwatch;

        protected Benchmark(string name, string description)
        {
            _description = description;
            _name = name;
            _stopwatch = new Stopwatch();
        }

        protected void StartStopwatch()
        {
            _stopwatch.Start();
        }

        protected TimeSpan ResetStopwatchAndReturnElapsed()
        {
            var elapsed = _stopwatch.Elapsed;
            _stopwatch.Reset();
            return elapsed;
        }

        protected void PrintBenchmarkDetails()
        {
            Console.WriteLine(_name);
            Console.WriteLine(_description);
        }
    }
}