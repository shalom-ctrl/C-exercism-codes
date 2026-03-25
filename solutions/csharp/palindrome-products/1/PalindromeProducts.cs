using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        var palindromes = new Dictionary<int, List<(int, int)>>();

        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                int product = i * j;

                if (IsPalindrome(product))
                {
                    if (!palindromes.ContainsKey(product))
                    {
                        palindromes[product] = new List<(int, int)>();
                    }

                    palindromes[product].Add((i, j));
                }
            }
        }

        if (palindromes.Count == 0)
            throw new ArgumentException("No palindrome products found.");

        int largest = palindromes.Keys.Max();
        return (largest, palindromes[largest]);
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        var palindromes = new Dictionary<int, List<(int, int)>>();

        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                int product = i * j;

                if (IsPalindrome(product))
                {
                    if (!palindromes.ContainsKey(product))
                    {
                        palindromes[product] = new List<(int, int)>();
                    }

                    palindromes[product].Add((i, j));
                }
            }
        }

        if (palindromes.Count == 0)
            throw new ArgumentException("No palindrome products found.");

        int smallest = palindromes.Keys.Min();
        return (smallest, palindromes[smallest]);
    }

    private static bool IsPalindrome(int number)
    {
        string str = number.ToString();
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        return str == new string(arr);
    }
}
