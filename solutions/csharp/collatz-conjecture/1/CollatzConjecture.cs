using System;

public static class CollatzConjecture
{
    public static int Steps(int n)
    {
        // 1. Validation: The conjecture only applies to positive integers
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Only positive integers are allowed.");
        }

        int steps = 0;
        
        // 2. Loop until we reach 1
        while (n != 1)
        {
            if (n % 2 == 0)
            {
                // Rule: If even, divide by 2
                n = n / 2;
            }
            else
            {
                // Rule: If odd, multiply by 3 and add 1
                n = (3 * n) + 1;
            }
            
            steps++;
        }

        return steps;
    }
}