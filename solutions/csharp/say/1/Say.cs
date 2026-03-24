using System;
using System.Collections.Generic;

public static class Say
{
    private static readonly string[] Ones = { 
        "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
        "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" 
    };

    private static readonly string[] Tens = { 
        "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" 
    };

    public static string InEnglish(long number)
    {
        if (number < 0 || number > 999_999_999_999L) 
            throw new ArgumentOutOfRangeException(nameof(number));
        if (number == 0) return "zero";

        var parts = new List<string>();

        // Process Billions
        if (number >= 1_000_000_000)
        {
            parts.Add($"{SmallNumberToEnglish(number / 1_000_000_000)} billion");
            number %= 1_000_000_000;
        }

        // Process Millions
        if (number >= 1_000_000)
        {
            parts.Add($"{SmallNumberToEnglish(number / 1_000_000)} million");
            number %= 1_000_000;
        }

        // Process Thousands
        if (number >= 1_000)
        {
            parts.Add($"{SmallNumberToEnglish(number / 1_000)} thousand");
            number %= 1_000;
        }

        // Process remaining Hundreds/Ones
        if (number > 0)
        {
            parts.Add(SmallNumberToEnglish(number));
        }

        return string.Join(" ", parts);
    }

    private static string SmallNumberToEnglish(long n)
    {
        if (n == 0) return "";
        if (n < 20) return Ones[n];
        if (n < 100)
        {
            var suffix = (n % 10 > 0) ? $"-{Ones[n % 10]}" : "";
            return $"{Tens[n / 10]}{suffix}";
        }
        
        // Handling 100-999
        var remainder = (n % 100 > 0) ? $" {SmallNumberToEnglish(n % 100)}" : "";
        return $"{Ones[n / 100]} hundred{remainder}";
    }
}