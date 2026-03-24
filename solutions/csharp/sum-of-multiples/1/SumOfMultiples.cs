using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        // 1. Start with a range of numbers from 1 to max-1
        return Enumerable.Range(1, Math.Max(0, max - 1))
            // 2. Filter for numbers divisible by ANY of the items
            .Where(number => multiples
                .Any(item => item > 0 && number % item == 0))
            // 3. Sum the results
            .Sum();
    }
}