using System;
using System.Linq;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        // 1. Remove hyphens
        string cleanIsbn = number.Replace("-", "");

        // 2. Length check
        if (cleanIsbn.Length != 10) return false;

        int totalSum = 0;

        for (int i = 0; i < 10; i++)
        {
            char c = cleanIsbn[i];
            int digitValue;

            if (char.IsDigit(c))
            {
                digitValue = c - '0';
            }
            else if (i == 9 && c == 'X')
            {
                // 'X' is only valid in the 10th position
                digitValue = 10;
            }
            else
            {
                // Any non-digit in the first 9 positions (or non-X in the 10th) is invalid
                return false;
            }

            // Multiply by the weight (10, 9, 8... 1)
            totalSum += digitValue * (10 - i);
        }

        // 3. Modulo check
        return totalSum % 11 == 0;
    }
}