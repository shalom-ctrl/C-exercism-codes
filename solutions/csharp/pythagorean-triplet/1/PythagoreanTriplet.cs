using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        var result = new List<(int a, int b, int c)>();

        // 'a' must be less than sum/3 because a < b < c
        for (int a = 1; a < sum / 3; a++)
        {
            // Derived formula for b:
            // b = (sum^2 - 2*sum*a) / (2*sum - 2*a)
            
            int numerator = (sum * sum) - (2 * sum * a);
            int denominator = 2 * (sum - a);

            // If the numerator is perfectly divisible by the denominator,
            // then 'b' is a whole number (an integer).
            if (numerator % denominator == 0)
            {
                int b = numerator / denominator;
                int c = sum - a - b;

                // Ensure the condition a < b < c is met
                if (b > a)
                {
                    result.Add((a, b, c));
                }
            }
        }

        return result;
    }
}