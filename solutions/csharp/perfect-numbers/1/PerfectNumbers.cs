using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Classification is only defined for positive integers.");
        }

        int aliquotSum = 0;

        // A proper divisor cannot be greater than half the number
        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                aliquotSum += i;
            }
        }

        if (aliquotSum == number)
        {
            return Classification.Perfect;
        }

        if (aliquotSum > number)
        {
            return Classification.Abundant;
        }

        return Classification.Deficient;
    }
}