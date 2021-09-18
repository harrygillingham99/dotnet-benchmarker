using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Benchmarker.Benchmarks.Templates;

namespace Benchmarker.Benchmarks
{
    public class ArraySorting : SimpleComparisonBenchmark
    {
        private static readonly List<int> TestList =
            Enumerable.Repeat(RandomNumberGenerator.GetInt32(0, 99999), 9999999).ToList();

        public ArraySorting() : base("Array Filtering", "Comparing methods of filtering arrays with a predicate",
            new List<(string variantName, Action benchmarkAction)>
            {
                ("Linq Sort", () =>
                {
                    var listCopy = new List<int>(TestList);
                    _ = listCopy.OrderBy(x => x);
                }),
                ("Bubble Sort", () =>
                {
                    var listCopy = new List<int>(TestList);
                    var itemMoved = false;
                    do
                    {
                        itemMoved = false;
                        for (var i = 0; i < listCopy.Count() - 1; i++)
                            if (listCopy[i] > listCopy[i + 1])
                            {
                                var lowerValue = listCopy[i + 1];
                                listCopy[i + 1] = listCopy[i];
                                listCopy[i] = lowerValue;
                                itemMoved = true;
                            }
                    } while (itemMoved);
                }),
                ("Insertion Sort", () =>
                {
                    var listCopy = new List<int>(TestList);

                    for (var i = 0; i < listCopy.Count(); i++)
                    {
                        var item = listCopy[i];
                        var currentIndex = i;

                        while (currentIndex > 0 && listCopy[currentIndex - 1] > item)
                        {
                            listCopy[currentIndex] = listCopy[currentIndex - 1];
                            currentIndex--;
                        }

                        listCopy[currentIndex] = item;
                    }
                })
            })
        {
        }
    }
}