using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        var factors = new List<long>();
        long divisor = 2;

        while (number > 1)
        {
            // While the current divisor fits perfectly into the number
            while (number % divisor == 0)
            {
                factors.Add(divisor);
                number /= divisor;
            }
            
            // Move to the next potential factor
            divisor++;
            
            // Optimization: If number is large, we could stop at sqrt(number),
            // but for a simple implementation, linear incrementing works fine.
        }

        return factors.ToArray();
    }
}