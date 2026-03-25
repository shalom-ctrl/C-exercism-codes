using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2) return Array.Empty<int>();

        // Step 1: Initialize the sieve. 
        // Index represents the number, value represents if it's prime.
        bool[] isPrime = new bool[limit + 1];
        for (int i = 2; i <= limit; i++) isPrime[i] = true;

        // Step 2: Apply the Sieve algorithm
        for (int p = 2; p * p <= limit; p++)
        {
            // If isPrime[p] is not changed, then it is a prime
            if (isPrime[p])
            {
                // Update all multiples of p starting from p*p
                // Numbers less than p*p would have already been marked
                for (int i = p * p; i <= limit; i += p)
                {
                    isPrime[i] = false;
                }
            }
        }

        // Step 3: Collect the results
        var primes = new List<int>();
        for (int i = 2; i <= limit; i++)
        {
            if (isPrime[i]) primes.Add(i);
        }

        return primes.ToArray();
    }
}